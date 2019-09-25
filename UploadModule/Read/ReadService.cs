// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Read
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Core.Items;
    using Core.Util;
    using Newtonsoft.Json;
    using NLog;

    /// <summary>
    ///     Represents a class for reading, parsing and validating input data.
    /// </summary>
    internal sealed class ReadService : IReadService
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        ///     Reads, parses and validates <see cref="BuildingItem"/> objects.
        /// </summary>
        /// <param name="filePath">The file path to load data from.</param>
        /// <returns>The sequence of validated <see cref="BuildingItem"/> objects.</returns>
        public IEnumerable<BuildingItem> ReadBuildings(string filePath)
        {
            var ids = new HashSet<int>();
            var count = 0;
            using (var reader = new FilteringTextReader(filePath))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = new JsonSerializer();
                // read
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType != JsonToken.StartObject)
                    {
                        continue;
                    }

                    // parse
                    var holder = serializer.Deserialize<BuildingItemHolder>(jsonReader);
                    count++;

                    // validate
                    var id = holder.Item.Id;
                    if (ids.Add(id))
                    {
                        yield return holder.Item;
                    }
                }
            }

            // log statistics
            Logger.Info($"Read {count} buildings, yielded {ids.Count} buildings.");
        }

        /// <summary>
        ///     Reads, parses and validates <see cref="CompanyItem"/> objects.
        /// </summary>
        /// <param name="filePath">The file path to load data from.</param>
        /// <returns>The sequence of validated <see cref="CompanyItem"/> objects.</returns>
        public IEnumerable<CompanyItem> ReadCompanies(string filePath)
        {
            var ids = new HashSet<int>();
            var count = 0;
            using (var reader = new FilteringTextReader(filePath))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var serializer = new JsonSerializer();
                // read
                while (jsonReader.Read())
                {
                    if (jsonReader.TokenType != JsonToken.StartObject)
                    {
                        continue;
                    }

                    // parse
                    var holder = serializer.Deserialize<CompanyItemHolder>(jsonReader);
                    count++;

                    // validate
                    var id = holder.Item.Id;
                    if (ids.Add(id))
                    {
                        yield return holder.Item;
                    }
                }
            }

            // log statistics
            Logger.Info($"Read {count} companies, yielded {ids.Count} companies.");
        }

        /// <summary>
        ///     Represents a class for filtering out EOL characters from the Unicode text stream.
        /// </summary>
        private class FilteringTextReader : TextReader
        {
            private readonly StreamReader _reader;

            public FilteringTextReader(string filename)
            {
                Check.NotEmpty(filename, nameof(filename));

                _reader = new StreamReader(filename, Encoding.Unicode);
            }

            public override int Read()
            {
                var character = _reader.Read();
                while (character == 13 || character == 10)
                {
                    character = _reader.Read();
                }

                return character;
            }

            public override int Peek()
            {
                throw new NotImplementedException();
            }

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _reader.Dispose();
                }

                base.Dispose(disposing);
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class BuildingItemHolder
        {
            [JsonProperty("property")]
            public BuildingItem Item { get; set; }
        }

        [JsonObject(MemberSerialization.OptIn)]
        private class CompanyItemHolder
        {
            [JsonProperty("mgmt")]
            public CompanyItem Item { get; set; }
        }
    }
}