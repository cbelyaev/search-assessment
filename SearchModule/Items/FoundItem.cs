// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace SearchModule.Items
{
    using Core.Items;

    /// <summary>
    ///     Represents an item found.
    /// </summary>
    public class FoundItem
    {
        public int Id { get; set; }
        public FoundItemType ItemType { get; set; }
        public string Name { get; set; }
        public string FormerName { get; set; }
        public string Market { get; set; }
        public string State { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
    }
}