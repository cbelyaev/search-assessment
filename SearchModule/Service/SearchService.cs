// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule.Service
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using Amazon.CloudSearchDomain;
    using Amazon.CloudSearchDomain.Model;
    using AutoMapper;
    using Config;
    using Core.Exceptions;
    using Core.Items;
    using Core.Util;
    using NLog;
    using Items;

    /// <summary>
    ///     Represents a service to search items.
    /// </summary>
    internal class SearchService : ISearchService
    {
        private const int MinResults = 1;
        private const int MaxResults = 100;
        private const string TermSeparator = " ";
        private const string MarketFieldName = "market";
        private const string OpenBracket = "(";
        private const string CloseBracket = ")";
        private const string AndOperator = "and";
        private const string OrOperator = "or";
        private const string TermOperator = "term";

        private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
        private static readonly Regex FilterRegex = new Regex("[^a-z0-9 -]");

        private readonly ISearchConfig _config;
        private readonly IMapper _mapper;

        public SearchService(ISearchConfig config, IMapper mapper)
        {
            _config = Check.NotNull(config, nameof(config));
            _mapper = Check.NotNull(mapper, nameof(mapper));
        }

        public async Task<IEnumerable<FoundItem>> Search(string query, IImmutableList<string> markets, int maxResults)
        {
            Check.NotEmpty(query, nameof(query));
            Check.NotNull(markets, nameof(markets));
            Check.InRange(ref maxResults, nameof(maxResults), MinResults, MaxResults);

            // parse and check query
            var terms = ParseQuery(query);
            if (terms.Length == 0)
            {
                throw new InvalidQueryException();
            }

            // build query
            var request = new SearchRequest
            {
                Query = BuildQuery(terms),
                FilterQuery = BuildFilterQuery(markets),
                Size = maxResults,
                QueryParser = QueryParser.Structured,
            };

            Logger.Info("Searching:");
            Logger.Info($"Query: {request.Query}");
            Logger.Info($"Filter: {request.FilterQuery}");
            Logger.Info($"Size: {request.Size}");

            try
            {
                using (var client = new AmazonCloudSearchDomainClient(_config.KeyId, _config.SecretKey, _config.ServiceUrl))
                {
                    // execute search
                    var response = await client.SearchAsync(request);

                    Logger.Info($"Status: {response.HttpStatusCode}");

                    // build result
                    var result = new List<FoundItem>(response.Hits.Hit.Count);
                    foreach (var hit in response.Hits.Hit)
                    {
                        var documentItem = BuildDocumentItem(hit.Fields);
                        var foundItem = _mapper.Map<FoundItem>(documentItem);
                        (foundItem.Id, foundItem.ItemType) = DocumentId.Parse(hit.Id);
                        result.Add(foundItem);
                    }

                    return result;
                }
            }
            catch (Exception ex)
            {
                throw new SearchErrorException(ex);
            }
        }

        private string[] ParseQuery(string query)
        {
            var filteredQuery = FilterRegex.Replace(query.ToLowerInvariant(), TermSeparator);
            var terms = filteredQuery.Split(TermSeparator, StringSplitOptions.RemoveEmptyEntries);
            var stopWords = _config.StopWords;
            var filteredTerms = terms.Where(t => !stopWords.Contains(t)).ToArray();
            return filteredTerms;
        }

        private static string BuildQuery(IEnumerable<string> terms)
        {
            var query = new StringBuilder($"{OpenBracket}{AndOperator}");
            foreach (var term in terms)
            {
                query.Append($" {OpenBracket}{TermOperator} '{term}'{CloseBracket}");
            }

            query.Append(CloseBracket);
            return query.ToString();
        }

        private static string BuildFilterQuery(IImmutableList<string> markets)
        {
            if (markets.Count == 0)
            {
                return null;
            }

            var query = new StringBuilder($"{OpenBracket}{OrOperator}");
            foreach (var market in markets)
            {
                query.Append($" {MarketFieldName}:'{market}'");
            }

            query.Append(CloseBracket);
            return query.ToString();
        }

        private static DocumentItem BuildDocumentItem(IReadOnlyDictionary<string, List<string>> fields)
        {
            var item = new DocumentItem
            {
                Name = FindFieldValue(fields, DocumentItem.NameField),
                FormerName = FindFieldValue(fields, DocumentItem.FormerNameField),
                Market = FindFieldValue(fields, DocumentItem.MarketField),
                State = FindFieldValue(fields, DocumentItem.StateField),
                Address = FindFieldValue(fields, DocumentItem.AddressField),
                City = FindFieldValue(fields, DocumentItem.CityField),
            };

            return item;
        }

        private static string FindFieldValue(IReadOnlyDictionary<string, List<string>> fields, string fieldName)
        {
            return fields.TryGetValue(fieldName, out var values) ? values.FirstOrDefault() : default;
        }
    }
}