// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Exceptions
{
    /// <summary>
    ///     Represents an invalid query error.
    /// </summary>
    public sealed class InvalidQueryException : BusinessLogicException
    {
        public override string UserFriendlyMessage => "Invalid query";
        public override object BlErrorData => null;
    }
}