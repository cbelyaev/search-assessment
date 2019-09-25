// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace UploadModule.Read
{
    using System.Collections.Generic;
    using Core.Items;

    /// <summary>
    ///     Represents an interface to read <see cref="BuildingItem"/> and <see cref="CompanyItem"/> objects
    ///     from the files.
    /// </summary>
    internal interface IReadService
    {
        /// <summary>
        ///     Reads, parses and validates <see cref="BuildingItem"/> objects.
        /// </summary>
        /// <param name="filePath">The file path to load data from.</param>
        /// <returns>The sequence of validated <see cref="BuildingItem"/> objects.</returns>
        IEnumerable<BuildingItem> ReadBuildings(string filePath);

        /// <summary>
        ///     Reads, parses and validates <see cref="CompanyItem"/> objects.
        /// </summary>
        /// <param name="filePath">The file path to load data from.</param>
        /// <returns>The sequence of validated <see cref="CompanyItem"/> objects.</returns>
        IEnumerable<CompanyItem> ReadCompanies(string filePath);
    }
}