# Claude Code Instructions

See `AGENTS.md` for shared conventions and documentation requirements that apply to all AI agents.

## Additional Claude-specific Notes

- A PostToolUse hook in `.claude/settings.json` automatically triggers documentation updates when source files are written or edited. If the hook fails or times out, manually update the docs.
- Use `dotnet build` to verify changes compile before committing.
- Swagger is Development-only; do not enable it for production.
