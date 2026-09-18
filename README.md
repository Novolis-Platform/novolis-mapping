<!-- novolis-marketing:start -->
<p align="center">
  <a href="https://github.com/Novolis-Platform">
    <img src="https://raw.githubusercontent.com/Novolis-Platform/.github/main/brand/logo-brand-transparent.svg" width="360" alt="Novolis"/>
  </a>
</p>

<p align="center">
  <img src="https://raw.githubusercontent.com/Novolis-Platform/.github/main/brand/banners/novolis-mapping.svg" width="100%" alt="novolis-mapping"/>
</p>

<p align="center">
  <strong>Mapping utilities</strong><br/>
  Mapping helpers for Novolis applications.
</p>

<p align="center">
  <a href="https://novolis-platform.github.io/.github/novolis-mapping/"><img src="https://img.shields.io/badge/docs-portfolio-0a7ea3" alt="docs"/></a>
  <a href="https://github.com/Novolis-Platform/novolis-mapping/actions"><img src="https://img.shields.io/github/actions/workflow/status/Novolis-Platform/novolis-mapping/merge.yml?branch=main&label=merge&logo=github" alt="merge"/></a>
  <a href="https://github.com/orgs/Novolis-Platform/packages?repo_name=novolis-mapping"><img src="https://img.shields.io/badge/packages-GitHub%20Packages-0a7ea3?logo=nuget" alt="packages"/></a>
  <a href="https://github.com/Novolis-Platform"><img src="https://img.shields.io/badge/org-Novolis--Platform-111827" alt="org"/></a>
</p>

<p align="center">
  <a href="https://novolis-platform.github.io/.github/novolis-mapping/">Docs</a>
  ·
  <a href="https://nuget.pkg.github.com/Novolis-Platform/index.json"><code>https://nuget.pkg.github.com/Novolis-Platform/index.json</code></a>
  ·
  <a href="https://github.com/Novolis-Platform/.github/blob/main/profile/README.md">Org landing</a>
  ·
  <a href="https://github.com/Novolis-Platform/novolis-governance">Governance</a>
</p>

---
<!-- novolis-marketing:end -->
# novolis-mapping

**Object mapping** for workflows and documents — DI-friendly definitions migrated from `Frank.Mapping`.

Published as `Novolis.Mapping` on GitHub Packages (`2026.1.*`). See [platform-import-plan.md](https://github.com/Novolis-Platform/novolis-governance/blob/main/docs/platform-import-plan.md).

## Package

| Package | Install | README |
|---------|---------|--------|
| `Novolis.Mapping` | `dotnet add package Novolis.Mapping` | [src/Novolis.Mapping/README.md](src/Novolis.Mapping/README.md) |

## Build

```bash
dotnet build
dotnet test
```

Packages publish to **GitHub Packages** on merge to `main` (restore: nuget.org + github only).

For local cross-repo iteration, open **`Novolis.Platform.slnx`** at the workspace root (ProjectReference mode).

## Documentation

- [Getting started](docs/getting-started.md)
- [Design](docs/design.md)
- [Release](docs/release.md)

## Contributing

See [CONTRIBUTING.md](CONTRIBUTING.md).

## Related

| Source | Notes |
|--------|-------|
| `Frank.Mapping` | Archived; use `Novolis.Mapping` for new work |
| `novolis-workflows` | Primary consumer of mapping definitions |

