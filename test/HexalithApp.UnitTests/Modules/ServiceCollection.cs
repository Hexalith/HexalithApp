// <copyright file="ServiceCollection.cs" company="ITANEO">
// Copyright (c) ITANEO (https://www.itaneo.com). All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.UnitTests.Modules;

using Microsoft.Extensions.DependencyInjection;

internal sealed class ServiceCollection : List<ServiceDescriptor>, IServiceCollection;