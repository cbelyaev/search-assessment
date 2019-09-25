// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Searcher.Config
{
    using System.Text;

    /// <summary>
    ///     Represents a class with configuration properties of JWT.
    /// </summary>
    public class JwtConfig
    {
        /// <summary>
        ///     Gets or sets an issuer of token.
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        ///     Gets or sets a key of token.
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        ///     Gets the bytes of key.
        /// </summary>
        public byte[] KeyBytes => Encoding.UTF8.GetBytes(Key);

        /// <summary>
        ///     Gets an audience of token.
        /// </summary>
        public string Audience => Issuer;
    }
}