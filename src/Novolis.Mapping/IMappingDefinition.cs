namespace Novolis.Mapping;

/// <summary>
/// Represents a mapping interface to convert objects from type TSource to type TDestination.
/// </summary>
/// <typeparam name="TSource">The type of object to be converted.</typeparam>
/// <typeparam name="TDestination">The type of converted object.</typeparam>
public interface IMappingDefinition<TSource, TDestination>
{
    /// <summary>Maps an instance of <typeparamref name="TSource"/> to <typeparamref name="TDestination"/>.</summary>
    /// <param name="source">The object to map.</param>
    /// <returns>The mapped object.</returns>
    TDestination Map(TSource source);
}
