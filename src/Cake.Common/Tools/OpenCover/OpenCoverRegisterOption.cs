// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using Cake.Core.IO;

using System;

namespace Cake.Common.Tools.OpenCover
{
    /// <summary>
    /// Represents the register-options:
    ///  - empty for admin-registry-access
    ///  - "user" for user-registry-access
    ///  - path for non-registry-dll dll
    /// </summary>
    public class OpenCoverRegisterOption
    {
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenCoverRegisterOption"/> class.
        /// </summary>
        /// <param name="value">The value.</param>
        public OpenCoverRegisterOption(string value)
        {
            this.value = value;
        }

        /// <summary>
        /// Converts to string.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            return $":{value}";
        }

        /// <summary>
        /// Gets the register-option representing the "user"-mode.
        /// (this will translate to -register:user)
        /// this
        /// </summary>
        public static OpenCoverRegisterOption User => new OpenCoverRegisterOption("user");

        /// <summary>
        /// Gets the register-option representing the "admin"-mode.
        /// (this will translate to -register)
        /// this
        /// </summary>
        public static OpenCoverRegisterOption Admin => new OpenCoverRegisterOption(string.Empty);

        /// <summary>
        /// Gets a register-option pointing to a dll.
        /// (this will translate to -register:[path-to-dll])
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The <see cref="OpenCoverRegisterOption"/></returns>
        public static OpenCoverRegisterOption Dll(FilePath path)
        {
            return new OpenCoverRegisterOption(path.FullPath);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.String"/> to <see cref="OpenCoverRegisterOption"/>.
        /// (Since the switch from pure string to <see cref="OpenCoverRegisterOption"/> is a breaking change)
        /// </summary>
        /// <param name="option">The option.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        [Obsolete("use new OpenCoverRegisterOption() instead.")]
        public static implicit operator OpenCoverRegisterOption(string option) => new OpenCoverRegisterOption(option);
    }
}