// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Exceptions
{
    using System;
    using System.Runtime.Serialization;

    /// <summary>
    ///     Represents a base class for all exceptions in the business logic.
    /// </summary>
    public abstract class BusinessLogicException : Exception
    {
        protected BusinessLogicException()
        {
        }

        protected BusinessLogicException(SerializationInfo info, StreamingContext context): base(info, context)
        {
        }

        protected BusinessLogicException(string message): base(message)
        {
        }

        protected BusinessLogicException(string message, Exception innerException): base(message, innerException)
        {
        }

        /// <summary>
        ///     Gets the user friendly message for the exception.
        /// </summary>
        public abstract string UserFriendlyMessage { get; }

        /// <summary>
        ///     Gets the business logic data for the exception.
        /// </summary>
        public abstract object BlErrorData { get; }
    }
}