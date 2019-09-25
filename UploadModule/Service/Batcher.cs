// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Service
{
    using System;
    using System.IO;
    using System.Text;
    using Core.Util;
    using NLog;

    /// <summary>
    ///     Represents a class for batching of json documents.
    /// </summary>
    internal sealed class Batcher: IDisposable
    {
        private const int MinBatchSize = 1 * 1024 * 1024;
        private const int MaxBatchSize = 5 * 1024 * 1024;

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private static readonly byte[] StartArray = Encoding.UTF8.GetBytes("[");
        private static readonly byte[] EndArray = Encoding.UTF8.GetBytes("]");
        private static readonly byte[] Comma = Encoding.UTF8.GetBytes(",");

        private readonly Action<Stream> _consumeAction;
        private readonly int _batchSize;
        private readonly byte[] _buffer;

        private MemoryStream _stream;

        public Batcher(int batchSize, Action<Stream> consumeAction)
        {
            _batchSize = Check.InRange(ref batchSize, nameof(batchSize), MinBatchSize, MaxBatchSize);
            _consumeAction = Check.NotNull(consumeAction, nameof(consumeAction));

            _buffer = new byte[_batchSize];
        }

        public void Write(string jsonDocument)
        {
            Check.NotEmpty(jsonDocument, nameof(jsonDocument));

            var bytes = Encoding.UTF8.GetBytes(jsonDocument);
            if (bytes.Length > _batchSize - StartArray.Length - EndArray.Length)
            {
                throw new ArgumentException("Too big", nameof(jsonDocument));
            }
            
            if (_stream == null)
            {
                StartBatch(bytes);
            }
            else if (_batchSize - _stream.Position > bytes.Length + EndArray.Length)
            {
                Write(bytes);
            }
            else
            {
                Flush();
                StartBatch(bytes);
            }
        }

        private void Write(byte[] bytes)
        {
            _stream.Write(Comma);
            _stream.Write(bytes);
        }

        private void StartBatch(byte[] bytes)
        {
            _stream = new MemoryStream(_buffer);
            _stream.Write(StartArray);
            _stream.Write(bytes);
        }

        public void Flush()
        {
            if (_stream == null)
            {
                // nothing to flush
                return;
            }

            _stream.Write(EndArray);
            var count = (int)_stream.Position;
            _stream.Dispose();
            _stream = null;

            using (var stream = new MemoryStream(_buffer, 0, count, false))
            {
                try
                {
                    _consumeAction(stream);
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                }
            }
        }

        public void Dispose()
        {
            Flush();
        }
    }
}