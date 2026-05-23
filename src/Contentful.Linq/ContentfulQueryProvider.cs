using System.Linq.Expressions;

namespace Contentful.Linq;

/// <summary>
/// LINQ provider that captures query expressions for Contentful translation.
/// </summary>
public sealed class ContentfulQueryProvider : IQueryProvider
{
    /// <inheritdoc />
    public IQueryable CreateQuery(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        var elementType = expression.Type.GetGenericArguments().FirstOrDefault()
            ?? throw new NotSupportedException($"Unable to determine the element type for expression '{expression}'.");

        var queryType = typeof(ContentfulQueryable<>).MakeGenericType(elementType);
        return (IQueryable)Activator.CreateInstance(queryType, this, expression)!;
    }

    /// <inheritdoc />
    public IQueryable<TElement> CreateQuery<TElement>(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        return new ContentfulQueryable<TElement>(this, expression);
    }

    /// <inheritdoc />
    public object? Execute(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        throw new NotSupportedException(
            "Contentful LINQ query execution is not implemented yet. Translate the expression first or use a supported async terminal operation once available.");
    }

    /// <inheritdoc />
    public TResult Execute<TResult>(Expression expression)
    {
        ArgumentNullException.ThrowIfNull(expression);

        throw new NotSupportedException(
            "Contentful LINQ query execution is not implemented yet. Translate the expression first or use a supported async terminal operation once available.");
    }
}
