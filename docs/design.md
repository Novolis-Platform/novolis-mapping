# Design

Object mapping for workflows and documents — DI-friendly definitions migrated from `Frank.Mapping`.

Published docs: [https://novolis-platform.github.io/.github/novolis-mapping/](https://novolis-platform.github.io/.github/novolis-mapping/)

## Layer placement

Follow [library-boundaries](https://github.com/Novolis-Platform/novolis-governance/blob/main/docs/library-boundaries.md). Mapping is a platform plumbing library (BCL + DI only). It must not take Avalonia, MAUI, Gaming, or Simulation package references.

## Goals

- Keep public APIs documented and packable as `Novolis.Mapping` on GitHub Packages.
- Prefer `Microsoft.Extensions.DependencyInjection` over a custom container.
- Document restore and ProjectReference-mode builds without local NuGet folder feeds.

## Non-goals

- Local NuGet folder feeds or committed cross-repo `ProjectReference` into sibling checkouts.
- A full AutoMapper replacement (convention profiles, flattening, collection strategies).
- Avalonia package references outside `Novolis.Avalonia.*`.

## Packages

- `Novolis.Mapping`

## Topics

- `dotnet`
- `mapping`
- `novolis`
