﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Cake.Common.Build.GitHubActions.Data;
using Cake.Core;

namespace Cake.Common.Build.GitHubActions
{
    /// <summary>
    /// Responsible for communicating with GitHub Actions.
    /// </summary>
    public class GitHubActionsProvider : IGitHubActionsProvider
    {
        private readonly ICakeEnvironment _environment;

        /// <summary>
        /// Initializes a new instance of the <see cref="GitHubActionsProvider"/> class.
        /// </summary>
        /// <param name="environment">The environment.</param>
        public GitHubActionsProvider(ICakeEnvironment environment)
        {
            _environment = environment ?? throw new ArgumentNullException(nameof(environment));
            Environment = new GitHubActionsEnvironmentInfo(environment);
        }

        /// <inheritdoc/>
        public bool IsRunningOnGitHubActions => _environment.GetEnvironmentVariable("GITHUB_ACTIONS")?.Equals("true", StringComparison.OrdinalIgnoreCase) ?? false;

        /// <inheritdoc/>
        public GitHubActionsEnvironmentInfo Environment { get; }
    }
}
