﻿using FluentAssertions;
using MICROSERVICEARCH.Application.Domain.Abstractions;
using MICROSERVICEARCH.Application.Domain.Options;
using NetArchTest.Rules;
using static MICROSERVICEARCH.Tests.ArchitectureTests.AssemblyReferences;

namespace MICROSERVICEARCH.Tests.ArchitectureTests;

[TestFixture]
public class DomainArchitectureTests
{
    [Test]
    public void DomainEntities_Should_InheritFromTheEntityTypeAndBeSealed()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .That()
            .ResideInNamespace("ONIONARCH.Domain.Entities")
            .Should()
            .Inherit(typeof(Entity))
            .And()
            .BeSealed()
            .GetResult();

        if (result.FailingTypeNames != null && result.FailingTypeNames.Any())
        {
            Console.WriteLine("Failing Entity Types:");
            foreach (var failingType in result.FailingTypeNames)
            {
                Console.WriteLine($"    {failingType}");
            }
        }
        result.IsSuccessful.Should().BeTrue();
    }

    [Test]
    public void DomainAssembly_ShouldNot_ReferenceAnyOtherProjects()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .ShouldNot()
            .HaveDependencyOnAll([
                "Application",
                "Infrastructure",
                "Persistence",
                "Presentation",
                "Tests"
            ])
            .GetResult();

        if (result.FailingTypeNames != null && result.FailingTypeNames.Any())
        {
            Console.WriteLine("Failing Reference Types:");
            foreach (var failingType in result.FailingTypeNames)
            {
                Console.WriteLine($"    {failingType}");
            }
        }
        result.IsSuccessful.Should().BeTrue();
    }

    [Test]
    public void OptionsEntities_Should_InheritFromTheBaseConfigTypeAndBeSealed()
    {
        var result = Types
            .InAssembly(DomainAssembly)
            .That()
            .ResideInNamespace("ONIONARCH.Domain.Options")
            .Should()
            .Inherit(typeof(BaseOptionsConfig))
            .And()
            .BeSealed()
            .GetResult();

        if (result.FailingTypeNames != null && result.FailingTypeNames.Any())
        {
            Console.WriteLine("Failing Options Types:");
            foreach (var failingType in result.FailingTypeNames)
            {
                Console.WriteLine($"    {failingType}");
            }
        }
        result.IsSuccessful.Should().BeTrue();
    }
}
