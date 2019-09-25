// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Util
{
    using System;
    using System.Text.RegularExpressions;

    /// <summary>
    ///     Provides static methods to parse markets string argument.
    /// </summary>
    public static class MarketParser
    {
        private static readonly Regex MarketFilterRegex = new Regex("[^a-zA-Z0-9 ]");
        private const string MarketSeparator = ",";

        /// <summary>
        ///     Parses the string argument to array of markets.
        /// </summary>
        /// <param name="text">The text to parse.</param>
        /// <returns>The array of markets</returns>
        public static string[] ParseMarkets(this string text)
        {
            return MarketFilterRegex.Replace(text, MarketSeparator)
                .Split(MarketSeparator, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
