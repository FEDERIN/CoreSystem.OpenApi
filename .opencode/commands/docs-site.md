---
name: docs-site
description: Audit/validate the MkDocs site (mkdocs.yml + docs/). Usage: /docs-site [scope]
---

Load the `docs-site` skill and apply it to the repository's documentation site.

Scope: $ARGUMENTS (optional; defaults to the whole site).

Steps:
1. Verify `mkdocs.yml` exists and its `nav` entries point at existing files under `docs/`.
2. Check `site_name`, `repo_url`, `site_url` match this repository (CoreSystem.OpenApi).
3. Confirm `requirements.txt` lists every plugin referenced in `mkdocs.yml`.
4. Run `mkdocs build --strict` and report any warnings or missing pages.
5. Do not edit until findings are agreed.