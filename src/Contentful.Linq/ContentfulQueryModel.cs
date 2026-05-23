namespace Contentful.Linq;

/// <summary>
/// Represents the Contentful query shape produced from a LINQ expression tree.
/// </summary>
/// <param name="ExpressionText">A diagnostic rendering of the source LINQ expression.</param>
public sealed record ContentfulQueryModel(string ExpressionText);
