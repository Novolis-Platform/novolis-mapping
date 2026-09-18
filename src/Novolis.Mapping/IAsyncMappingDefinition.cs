namespace Novolis.Mapping;

/// <summary>
/// Represents an asynchronous mapping between two types. You can use this interface to map from one type to another asynchronously, for example if you need to make a web request to get the data to map to.
/// </summary>
/// <typeparam name="TSource">The source type to map from.</typeparam>
/// <typeparam name="TDestination">The destination type to map to.</typeparam>
public interface IAsyncMappingDefinition<TSource, TDestination>
{
    /// <summary>Maps <typeparamref name="TSource"/> to <typeparamref name="TDestination"/> asynchronously.</summary>
    /// <param name="source">The object to map.</param>
    /// <returns>The mapped object.</returns>
    Task<TDestination> MapAsync(TSource source);
}
