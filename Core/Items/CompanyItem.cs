// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Items
{
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a class for management company.
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class CompanyItem
    {
        [JsonProperty("mgmtID")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("market")]
        public string Market { get; set; }

        [JsonProperty("state")]
        public string State { get; set; }
    }
}