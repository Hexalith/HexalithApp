// <copyright file="ModuleManagerTest.cs" company="Fiveforty SAS Paris France">
//     Copyright (c) Fiveforty SAS Paris France. All rights reserved.
//     Licensed under the MIT license.
//     See LICENSE file in the project root for full license information.
// </copyright>

namespace HexalithApp.UnitTests.Modules;

using FluentAssertions;

using Hexalith.Application.Modules;
using Hexalith.Application.Modules.Configurations;

using HexalithApp.Client.Modules;
using HexalithApp.Server.Modules;
using HexalithApp.Shared.Modules.Models;

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

using Moq;

public class ModuleManagerTest
{
    [Fact]
    public void ModuleManagerShouldReturnClientAssemby()
    {
        ILogger<ModuleManager> logger = Mock.Of<ILogger<ModuleManager>>();
        IOptions<ModuleSettings> options = Options.Create(new ModuleSettings());

        ModuleManager manager = new([], options, logger);
        _ = ModuleManager.ClientModuleTypes.Should().HaveCount(1);
        _ = manager
            .ClientPresentationAssemblies
            .Should()
            .Contain(typeof(HexalithClientModule).Assembly);
    }

    [Fact]
    public void ModuleManagerShouldReturnClientModule()
    {
        ILogger<ModuleManager> logger = Mock.Of<ILogger<ModuleManager>>();
        IOptions<ModuleSettings> options = Options.Create(new ModuleSettings());

        ModuleManager manager = new([], options, logger);
        _ = ModuleManager.ClientModuleTypes.Should().HaveCount(1);
        _ = manager
            .ClientModules
            .Select(p => p.Value)
            .OfType<HexalithClientModule>()
            .Should()
            .HaveCount(1);
    }

    [Fact]
    public void ModuleManagerShouldReturnServerAssemby()
    {
        ILogger<ModuleManager> logger = Mock.Of<ILogger<ModuleManager>>();
        IOptions<ModuleSettings> options = Options.Create(new ModuleSettings());

        ModuleManager manager = new([], options, logger);
        _ = ModuleManager.ServerModuleTypes.Should().HaveCount(1);
        _ = manager
            .ServerPresentationAssemblies
            .Should()
            .Contain(typeof(HexalithServerModule).Assembly);
    }

    [Fact]
    public void ModuleManagerShouldReturnServerModule()
    {
        ILogger<ModuleManager> logger = Mock.Of<ILogger<ModuleManager>>();
        IOptions<ModuleSettings> options = Options.Create(new ModuleSettings());

        ModuleManager manager = new([], options, logger);
        _ = ModuleManager.ServerModuleTypes.Should().HaveCount(1);
        _ = manager
            .ServerModules
            .Select(p => p.Value)
            .OfType<HexalithServerModule>()
            .Should()
            .HaveCount(1);
    }

    [Fact]
    public void ModuleManagerShouldReturnSharedModule()
    {
        ILogger<ModuleManager> logger = Mock.Of<ILogger<ModuleManager>>();
        IOptions<ModuleSettings> options = Options.Create(new ModuleSettings());

        ModuleManager manager = new([], options, logger);
        _ = ModuleManager.SharedModuleTypes.Should().HaveCount(1);
        _ = manager
            .SharedModules
            .Select(p => p.Value)
            .OfType<HexalithSharedModule>()
            .Should()
            .HaveCount(1);
    }

    [Fact]
    public void ReflectionShouldFindClientModuleType()
    {
        _ = ModuleManager.ClientModuleTypes.Should().HaveCount(1);
        _ = ModuleManager.ClientModuleTypes.FirstOrDefault(p => p == typeof(HexalithClientModule));
    }

    [Fact]
    public void ReflectionShouldFindServerModuleType()
    {
        _ = ModuleManager.ServerModuleTypes.Should().HaveCount(1);
        _ = ModuleManager.ServerModuleTypes.FirstOrDefault(p => p == typeof(HexalithServerModule));
    }

    [Fact]
    public void ReflectionShouldFindSharedModuleType()
    {
        _ = ModuleManager.SharedModuleTypes.Should().HaveCount(1);
        _ = ModuleManager.SharedModuleTypes.FirstOrDefault(p => p == typeof(HexalithSharedModule));
    }
}