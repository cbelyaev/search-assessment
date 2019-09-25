// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Service
{
    using System.IO;
    using Amazon.CloudSearchDomain;
    using Amazon.CloudSearchDomain.Model;
    using AutoMapper;
    using Core.Items;
    using Core.Util;
    using Config;
    using Read;
    using Newtonsoft.Json;
    using NLog;

    /// <summary>
    ///     Represents an uploading service.
    /// </summary>
    internal class Uploader : IUploader
    {
        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();

        private readonly IUploaderConfig _config;
        private readonly IReadService _reader;
        private readonly IMapper _mapper;

        public Uploader(IUploaderConfig config, IReadService readService, IMapper mapper)
        {
            _config = Check.NotNull(config, nameof(config));
            _reader = Check.NotNull(readService, nameof(readService));
            _mapper = Check.NotNull(mapper, nameof(mapper));
        }

        public void Run()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.None,
            };

            using (var client = new AmazonCloudSearchDomainClient(_config.KeyId, _config.SecretKey, _config.ServiceUrl))
            using (var batcher = new Batcher(_config.BatchSize, stream => UploadBatch(client, stream)))
            {
                foreach (var building in _reader.ReadBuildings(_config.BuildingsFilePath))
                {
                    var addOperation = new AddOperation
                    {
                        Id = DocumentId.Build(building),
                        Fields = _mapper.Map<DocumentItem>(building),
                    };

                    var json = JsonConvert.SerializeObject(addOperation, settings);
                    batcher.Write(json);
                }

                foreach (var company in _reader.ReadCompanies(_config.CompaniesFilePath))
                {
                    var addOperation = new AddOperation
                    {
                        Id = DocumentId.Build(company),
                        Fields = _mapper.Map<DocumentItem>(company),
                    };
                    var json = JsonConvert.SerializeObject(addOperation, settings);
                    batcher.Write(json);
                }
            }

            void UploadBatch(IAmazonCloudSearchDomain client, Stream stream)
            {
                var request = new UploadDocumentsRequest();
                request.ContentType = ContentType.ApplicationJson;
                request.Documents = stream;
                Logger.Info($"Uploading batch with {stream.Length} bytes");
                var task = client.UploadDocumentsAsync(request);
                if (!task.Wait(_config.Timeout))
                {
                    Logger.Error("Operation timeout.");
                    return;
                }

                var response = task.Result;
                Logger.Info($"Operation results: {response.Status}, " +
                            $"added {response.Adds} documents, " +
                            $"warnings: {response.Warnings.Count}");
                foreach (var warning in response.Warnings)
                {
                    Logger.Info($"Operation warning: {warning}");
                }
            }
        }

        [JsonObject(MemberSerialization.OptIn)]
        private sealed class AddOperation
        {
            [JsonProperty("type")]
            public string OperationType => "add";

            [JsonProperty("id")]
            public string Id { get; set; }

            [JsonProperty("fields")]
            public DocumentItem Fields { get; set; }
        }

    }
}