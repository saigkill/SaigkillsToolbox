# 2. HandlingOfS2139

2024-10-01

## Status

Accepted

## Context

Code Style

## Decision

In some cases i'm using

catch(Exception ex)
{
  _logger.LogError(ex, "message", ex.Message)
}

This decision was used, because the error handling should handled by the caller method. The handling itself can differ between personal use cases.

## Consequences

Sonarlint is pacified. If you think, its better, to handle the issue directly in that WriteAsync method, your welcome to open a pull request.
