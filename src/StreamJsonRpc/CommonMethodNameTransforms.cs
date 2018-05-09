﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace StreamJsonRpc
{
    using System;
    using Microsoft;

    /// <summary>
    /// Common RPC method transform functions that may be supplied to <see cref="JsonRpc.AddLocalRpcTarget(object, System.Func{string, string})"/>.
    /// </summary>
    public static class CommonMethodNameTransforms
    {
        /// <summary>
        /// Gets a function that converts a given string's first character to lowercase.
        /// </summary>
        public static Func<string, string> CamelCase
        {
            get
            {
                return name =>
                {
                    if (name == null)
                    {
                        throw new ArgumentNullException();
                    }

                    if (name.Length == 0)
                    {
                        return string.Empty;
                    }

                    return name.Substring(0, 1).ToLowerInvariant() + name.Substring(1);
                };
            }
        }

        /// <summary>
        /// Gets a function that prepends a particular namespace and a period in front of any RPC method name.
        /// </summary>
        /// <param name="ns">
        /// The namespace to prefix to a method name, not including the trailing period.
        /// This value must not be null.
        /// When this value is the empty string, no transformation is performed by the returned function.
        /// </param>
        /// <returns>The transform function.</returns>
        public static Func<string, string> AddNamespacePrefix(string ns)
        {
            Requires.NotNull(ns, nameof(ns));

            if (ns.Length == 0)
            {
                return name => name;
            }

            return name => ns + "." + name;
        }
    }
}
