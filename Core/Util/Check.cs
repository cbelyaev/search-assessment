// <copyright company="Constantin Belyaev">
// Copyright (C) 2019 Constantin Belyaev. All Rights Reserved.
// </copyright>

namespace Core.Util
{
    using System;
    using System.Diagnostics;

    /// <summary>
    ///     Provides static methods for arguments validation.
    /// </summary>
    [DebuggerStepThrough]
    public static class Check
    {
        public static string NotEmpty(string value, string parameterName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException($"Argument {parameterName} is empty.");
            }

            return value;
        }

        public static T NotNull<T>(T value, string parameterName) where T : class
        {
            if (value == null)
            {
                throw new ArgumentNullException(parameterName);
            }

            return value;
        }

        public static ref T InRange<T>(ref T value, string parameterName, T lowerBound, T upperBound)
            where T : struct, IComparable<T>
        {
            if (value.CompareTo(lowerBound) < 0 || value.CompareTo(upperBound) > 0)
            {
                NotEmpty(parameterName, nameof(parameterName));

                var message = string.Format("Argument {0} must be in range [{1}, {2}].", parameterName, lowerBound, upperBound);
                throw new ArgumentOutOfRangeException(parameterName, value, message);
            }

            return ref value;
        }
    }
}