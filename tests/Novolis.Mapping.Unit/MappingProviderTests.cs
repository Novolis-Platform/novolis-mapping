using Microsoft.Extensions.DependencyInjection;
using Novolis.Mapping;

namespace Novolis.Mapping.Unit;

public sealed class MappingProviderTests
{
    private sealed class Source
    {
        public string Value { get; init; } = string.Empty;
    }

    private sealed class Target
    {
        public string Value { get; init; } = string.Empty;
    }

    [Test]
    public async Task SimpleMapping_round_trips()
    {
        var services = new ServiceCollection();
        services.AddSimpleMapping<string, string>(s => s.ToUpperInvariant());
        await using var provider = services.BuildServiceProvider();
        var mapping = provider.GetRequiredService<IMappingProvider>();
        await Assert.That(mapping.Map<string, string>("hi")).IsEqualTo("HI");
    }

    [Test]
    public async Task GetMappingDefinition_returns_registered_definition()
    {
        var services = new ServiceCollection();
        services.AddSimpleMapping<Source, Target>(s => new Target { Value = s.Value.ToUpperInvariant() });
        await using var provider = services.BuildServiceProvider();
        var mappingProvider = provider.GetRequiredService<IMappingProvider>();

        var definition = mappingProvider.GetMappingDefinition<Source, Target>();

        await Assert.That(definition.Map(new Source { Value = "abc" }).Value).IsEqualTo("ABC");
    }

    [Test]
    public async Task GetMappingDefinition_throws_when_not_registered()
    {
        await using var provider = new ServiceCollection().BuildServiceProvider();
        var mappingProvider = new MappingProvider(provider);

        await Assert.That(() => mappingProvider.GetMappingDefinition<Source, Target>())
            .Throws<MappingDefinitionNotFoundException>()
            .WithMessageContaining("No mapping definition found for Source to Target");
    }

    [Test]
    public async Task Map_throws_when_not_registered()
    {
        await using var provider = new ServiceCollection().BuildServiceProvider();
        var mappingProvider = new MappingProvider(provider);

        await Assert.That(() => mappingProvider.Map<Source, Target>(new Source { Value = "x" }))
            .Throws<MappingDefinitionNotFoundException>()
            .WithMessageContaining("No mapping definition found for Source to Target");
    }
}
