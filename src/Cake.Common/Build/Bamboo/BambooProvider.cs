﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Cake.Common.Build.Bamboo.Data;
using Cake.Core;

namespace Cake.Common.Build.Bamboo
{
    /// <summary>
    /// Responsible for communicating with Bamboo.
    /// </summary>
    public sealed class BambooProvider : IBambooProvider
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="BambooProvider"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public BambooProvider(ICakeEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            Environment = new BambooEnvironmentInfo(environment);
        }

        /// <inheritdoc/>
        public bool IsRunningOnBamboo => !string.IsNullOrWhiteSpace(_environment.GetEnvironmentVariable("bamboo_buildNumber"));

        /// <inheritdoc/>
        public BambooEnvironmentInfo Environment { get; }
    }
}