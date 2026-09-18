using Microsoft.Extensions.DependencyInjection;
using Novolis.Mapping;

namespace Novolis.Mapping.Unit;

public sealed class ServiceCollectionExtensionsTests
{
    private sealed class Source
    {
        public string Value { get; init; } = string.Empty;
    }

    private sealed class Target
    {
        public string Value { get; init; } = string.Empty;
    }

    private sealed class SourceToTargetMapping : IMappingDefinition<Source, Target>
    {
        public Target Map(Source from) => new() { Value = from.Value + "!" };
    }

    private sealed class AsyncSourceToTargetMapping : IAsyncMappingDefinition<Source, Target>
    {
        public Task<Target> MapAsync(Source source) =>
            Task.FromResult(new Target { Value = source.Value.ToUpperInvariant() });
    }

    [Test]
    public async Task AddMappingDefinition_resolves_mapping_and_provider()
    {
        var services = new ServiceCollection();
        services.AddMappingDefinition<Source, Target, SourceToTargetMapping>();
        await using var provider = services.BuildServiceProvider();

        var mappingProvider = provider.GetRequiredService<IMappingProvider>();
        var definition = provider.GetRequiredService<IMappingDefinition<Source, Target>>();

        await Assert.That(mappingProvider.Map<Source, Target>(new Source { Value = "hi" }).Value).IsEqualTo("hi!");
        await Assert.That(definition.Map(new Source { Value = "yo" }).Value).IsEqualTo("yo!");
    }

    [Test]
    public async Task AddMappingDefinition_does_not_register_duplicate_provider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IMappingProvider, MappingProvider>();
        services.AddMappingDefinition<Source, Target, SourceToTargetMapping>();

        var providerDescriptors = services
            .Where(d => d.ServiceType == typeof(IMappingProvider))
            .ToArray();

        await Assert.That(providerDescriptors.Length).IsEqualTo(1);
    }

    [Test]
    public async Task AddAsyncMappingDefinition_resolves_async_mapping_and_provider()
    {
        var services = new ServiceCollection();
        services.AddAsyncMappingDefinition<Source, Target, AsyncSourceToTargetMapping>();
        await using var provider = services.BuildServiceProvider();

        var mappingProvider = provider.GetRequiredService<IMappingProvider>();
        var asyncDefinition = provider.GetRequiredService<IAsyncMappingDefinition<Source, Target>>();

        await Assert.That(mappingProvider).IsNotNull();
        await Assert.That(asyncDefinition.MapAsync(new Source { Value = "hi" }).Result.Value).IsEqualTo("HI");
    }

    [Test]
    public async Task AddAsyncMappingDefinition_does_not_register_duplicate_provider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IMappingProvider, MappingProvider>();
        services.AddAsyncMappingDefinition<Source, Target, AsyncSourceToTargetMapping>();

        var providerDescriptors = services
            .Where(d => d.ServiceType == typeof(IMappingProvider))
            .ToArray();

        await Assert.That(providerDescriptors.Length).IsEqualTo(1);
    }

    [Test]
    public async Task AddSimpleMapping_null_map_throws()
    {
        var services = new ServiceCollection();

        await Assert.That(() => services.AddSimpleMapping<Source, Target>(null!))
            .Throws<ArgumentNullException>();
    }

    [Test]
    public async Task AddSimpleMapping_does_not_register_duplicate_provider()
    {
        var services = new ServiceCollection();
        services.AddSingleton<IMappingProvider, MappingProvider>();
        services.AddSimpleMapping<Source, Target>(s => new Target { Value = s.Value });

        var providerDescriptors = services
            .Where(d => d.ServiceType == typeof(IMappingProvider))
            .ToArray();

        await Assert.That(providerDescriptors.Length).IsEqualTo(1);
    }
}
