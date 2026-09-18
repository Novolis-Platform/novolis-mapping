<!-- novolis-pkg-brand:start -->
<p align="center">
  <a href="https://github.com/Novolis-Platform/novolis-mapping">
    <img src="https://raw.githubusercontent.com/Novolis-Platform/.github/main/brand/logo-icon.svg" width="72" alt="Novolis"/>
  </a>
</p>
<!-- novolis-pkg-brand:end -->

# Novolis.Mapping

DI-friendly **mapping definitions** migrated from `Frank.Mapping`. Register sync or async mappers, resolve through `IMappingProvider`.

## Install

```bash
dotnet add package Novolis.Mapping
```

Depends on `Microsoft.Extensions.DependencyInjection.Abstractions`.

## Quick start — inline mapper

```csharp
using Microsoft.Extensions.DependencyInjection;
using Novolis.Mapping;

services.AddSimpleMapping<SourceDto, DestDto>(s => new DestDto { Id = s.Id, Name = s.Name });

var provider = services.BuildServiceProvider().GetRequiredService<IMappingProvider>();
var dest = provider.Map<SourceDto, DestDto>(source);
```

## Quick start — class mapper

```csharp
services.AddMappingDefinition<Order, OrderView, OrderToViewMapping>();
// OrderToViewMapping : IMappingDefinition<Order, OrderView>

services.AddAsyncMappingDefinition<RemoteDoc, LocalDoc, RemoteDocImporter>();
// RemoteDocImporter : IAsyncMappingDefinition<RemoteDoc, LocalDoc>
```

## API

| Type | Role |
|------|------|
| `IMappingProvider` | `Map<TFrom,TTo>`, `GetMappingDefinition<TFrom,TTo>` |
| `MappingProvider` | Default resolver from `IServiceProvider` |
| `IMappingDefinition<TFrom,TTo>` | Sync `Map(source)` |
| `IAsyncMappingDefinition<TFrom,TTo>` | Async `MapAsync(source)` |
| `ServiceCollectionExtensions` | `AddSimpleMapping`, `AddMappingDefinition`, `AddAsyncMappingDefinition` |
| `MappingDefinitionNotFoundException` | Thrown when pair is not registered |

## Related

| Package / repo | Role |
|----------------|------|
| `novolis-workflows` | Workflow document mapping |
| `Frank.Mapping` | Superseded archived source |

