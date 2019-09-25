// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Exceptions
{
    using System;

    /// <summary>
    ///     Represents an error that occurs during search.
    /// </summary>
    public sealed class SearchErrorException : BusinessLogicException
    {
        public SearchErrorException(Exception ex) : base(ex.Message, ex)
        {
        }

        public override string UserFriendlyMessage => "Search error: " + Message;
        public override object BlErrorData => null;
    }
}