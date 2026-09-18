namespace Novolis.Mapping;

/// <summary>Thrown when no mapping is registered for a type pair.</summary>
public class MappingDefinitionNotFoundException : Exception
{
    /// <summary>Creates an exception for the missing mapping.</summary>
    public MappingDefinitionNotFoundException(Type from, Type to) : base($"No mapping definition found for {from.Name} to {to.Name}")
    {
    }
}
