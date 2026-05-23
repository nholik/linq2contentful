# Contentful.Linq Plan

## Bootstrap Findings

- The repository started as a mostly empty `netstandard2.0` class library under the `nlh3.contentful.linq` namespace.
- The local machine has modern .NET SDKs installed, including .NET 8, so the new solution targets `net8.0`.
- The official Contentful .NET SDK package is `contentful.csharp`; it exposes the `Contentful.Core` APIs used by the docs.
- Contentful's SDK already provides `Contentful.Core.Search.QueryBuilder<T>`, so the first real compiler should target that builder instead of constructing raw API URLs directly.
- The initial test strategy should assert expression-to-model and model-to-query-builder behavior before adding live Contentful API integration.

## First Milestones

1. Define entry/content-type mapping attributes or conventions.
2. Translate a strict subset of `Where`, `OrderBy`, `OrderByDescending`, `Skip`, and `Take`.
3. Convert the internal query model into `QueryBuilder<T>`.
4. Add async terminal operations that execute through the Contentful SDK.
5. Throw clear `NotSupportedException`s for expressions that cannot be represented by Contentful's Content Delivery API.

## Supported LINQ Subset For V0

- Field comparisons: `==`, `!=`, `>`, `>=`, `<`, and `<=`.
- Null checks for field existence.
- Boolean `&&` composition inside `Where`.
- Single-field ordering.
- `Skip` and `Take` pagination.

## Deferred

- `Select`, `GroupBy`, joins, projections, and client-side computed expressions.
- `OR` expressions and linked-entry traversal.
- Live Contentful integration tests requiring credentials.
