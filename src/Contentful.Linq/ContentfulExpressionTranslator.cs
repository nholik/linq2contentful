using System.Linq.Expressions;

namespace Contentful.Linq;

/// <summary>
/// Translates LINQ expression trees into the internal Contentful query model.
/// </summary>
public sealed class ContentfulExpressionTranslator
{
    /// <summary>
    /// Creates a query model from a LINQ expression tree.
    /// </summary>
    /// <param name="expression">The LINQ expression tree to translate.</param>
    /// <returns>A minimal query model that records the original expression.</returns>
    public ContentfulQueryModel Translate(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        return new ContentfulQueryModel(expression.ToString());
    }
}
