// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Items
{
    using Util;

    /// <summary>
    ///     Provides static methods for building and parsing the <see cref="DocumentItem"/> identificator.
    /// </summary>
    public static class DocumentId
    {
        private const string BuildingPrefix = "bi";
        private const string CompanyPrefix = "ci";

        /// <summary>
        ///     Builds the <see cref="DocumentItem"/> identificator for <see cref="BuildingItem"/>.
        /// </summary>
        /// <param name="buildingItem">The <see cref="BuildingItem"/> to build id for.</param>
        /// <returns>The <see cref="DocumentItem"/> identificator</returns>
        public static string Build(BuildingItem buildingItem) => $"{BuildingPrefix}{buildingItem.Id}";

        /// <summary>
        ///     Builds the <see cref="DocumentItem"/> identificator for <see cref="CompanyItem"/>.
        /// </summary>
        /// <param name="companyItem">The <see cref="CompanyItem"/> to build id for.</param>
        /// <returns>The <see cref="DocumentItem"/> identificator</returns>
        public static string Build(CompanyItem companyItem) => $"{CompanyPrefix}{companyItem.Id}";

        /// <summary>
        ///     Parses a <see cref="DocumentItem"/> identificator.
        /// </summary>
        /// <param name="documentId">The <see cref="DocumentItem"/> identificator to parse.</param>
        /// <returns>The integer id and type of item.</returns>
        public static (int id, FoundItemType itemType) Parse(string documentId)
        {
            Check.NotEmpty(documentId, nameof(documentId));

            if (documentId.StartsWith(BuildingPrefix))
            {
                int.TryParse(documentId.Substring(BuildingPrefix.Length), out var id);
                return (id, FoundItemType.Building);
            }
            
            if (documentId.StartsWith(CompanyPrefix))
            {
                int.TryParse(documentId.Substring(CompanyPrefix.Length), out var id);
                return (id, FoundItemType.Company);
            }

            return (default, FoundItemType.Unknown);
        }
    }
}