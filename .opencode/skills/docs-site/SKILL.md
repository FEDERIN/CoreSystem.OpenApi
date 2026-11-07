---
name: Docs Site (MkDocs)
description: Use when editing mkdocs.yml, the docs/ folder, navigation entries, or running mkdocs build. Covers nav integrity, page existence, strict build, and keeping docs pages aligned with the source in src/.
---

# Docs Site (MkDocs)

## Scope

This skill owns everything under `docs/` and `mkdocs.yml`. For type-name and
signature accuracy of code examples, also apply the `docs-accuracy` skill.

## Rules

1. **Every `nav` entry must point at an existing file.** `mkdocs build --strict`
   fails otherwise. Add the page before (or in the same change as) the nav entry.
2. **One page per nav leaf.** Do not leave orphan pages that are not reachable
   from `nav` unless they are intentionally hidden.
3. **Keep `site_name`, `repo_url` and `site_url` aligned with the actual
   repository.** This repo is `CoreSystem.OpenApi` (not the whole CoreSystem
   monorepo); update them when the docs are scoped to this project.
4. **Nav labels and file paths use the project's real package/module names**
   (e.g. `OpenApi`, not a stale monorepo name).
5. **Run `mkdocs build --strict` locally** after any nav or page change. It is
   the gate CI uses (`.github/workflows/documentation.yml`).
6. **Dependencies**: `requirements.txt` must list `mkdocs`, `mkdocs-material`
   and any plugins referenced in `mkdocs.yml` (e.g. `mkdocs-mermaid2-plugin`).
7. **Keep docs aligned with `src/`.** Page content (type names, signatures, package ids,
   install commands, code examples) must match the actual source. For detailed
   accuracy checks, also apply the `docs-accuracy` skill.
8. **READMEs feed the site.** Package READMEs (`src/*/README.md`) are the source of
   truth for package-level content. When building or updating the site, mirror
   their accurate content into `docs/` pages, but only after verifying the README
   is up to date with the source (apply `docs-accuracy`). Do not copy stale
   README content into the site.

## Verification

```
mkdocs build --strict
```

Must exit 0 with no warnings.