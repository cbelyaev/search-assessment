// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Items
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    ///     Represents a type of found item.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum FoundItemType
    {
        Unknown = -1,
        Building = 0,
        Company = 1
    }
}