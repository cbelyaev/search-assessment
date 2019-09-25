// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Items
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a class for appartment.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class BuildingItem
    {
        [JsonProperty("propertyID")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("formerName")]
        public string FormerName { get; set; }

        [JsonProperty("streetAddress")]
        public string Address { get; set; }

        [JsonProperty("city")]
        public string City { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
        
        [JsonProperty("lat")]
        public float Latitude { get; set; }

        [JsonProperty("lng")]
        public float Longitude { get; set; }
    }
}