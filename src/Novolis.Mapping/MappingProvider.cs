using Microsoft.Extensions.DependencyInjection;

namespace Novolis.Mapping;

/// <inheritdoc />
public class MappingProvider(IServiceProvider serviceProvider) : IMappingProvider
{
    /// <inheritdoc />
    public TTo Map<TFrom, TTo>(TFrom from) => GetMappingDefinition<TFrom, TTo>().Map(from);

    /// <inheritdoc />
    public IMappingDefinition<TFrom, TTo> GetMappingDefinition<TFrom, TTo>()
    {
        var mappingDefinition = serviceProvider.GetService<IMappingDefinition<TFrom, TTo>>();
        if (mappingDefinition is null)
            throw new MappingDefinitionNotFoundException(typeof(TFrom), typeof(TTo));
        return mappingDefinition;
    }
}
