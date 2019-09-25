// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Items
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a class for storing in the search index.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class DocumentItem
    {
        public const string NameField = "name";
        public const string FormerNameField = "former_name";
        public const string MarketField = "market";
        public const string StateField = "state";
        public const string AddressField = "address";
        public const string CityField = "city";

        [JsonProperty(NameField)]
        public string Name { get; set; }

        [JsonProperty(FormerNameField)]
        public string FormerName { get; set; }

        [JsonProperty(MarketField)]
        public string Market { get; set; }

        [JsonProperty(StateField)]
        public string State { get; set; }

        [JsonProperty(AddressField)]
        public string Address { get; set; }

        [JsonProperty(CityField)]
        public string City { get; set; }
    }
}