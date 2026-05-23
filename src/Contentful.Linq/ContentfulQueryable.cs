using System.Collections;
using System.Linq.Expressions;

namespace Contentful.Linq;

/// <summary>
/// Query root for Contentful entries.
/// </summary>
/// <typeparam name="T">The entry model type.</typeparam>
public sealed class ContentfulQueryable<T> : IOrderedQueryable<T>
{
    /// <summary>
    /// Initializes a new Contentful query root.
    /// </summary>
    public ContentfulQueryable()
        : this(new ContentfulQueryProvider(), null)
    {
    }

    /// <summary>
    /// Initializes a query with an existing provider and expression tree.
    /// </summary>
    /// <param name="provider">The provider that owns the expression tree.</param>
    /// <param name="expression">The expression represented by this query.</param>
    public ContentfulQueryable(ContentfulQueryProvider provider, Expression? expression)
    {
        Provider = provider ?? throw new ArgumentNullException(nameof(provider));
        Expression = expression ?? Expression.Constant(this);
    }

    /// <inheritdoc />
    public Type ElementType => typeof(T);

    /// <inheritdoc />
    public Expression Expression { get; }

    /// <inheritdoc />
    public IQueryProvider Provider { get; }

    /// <inheritdoc />
    public IEnumerator<T> GetEnumerator()
    {
        throw new NotSupportedException(
            "Contentful LINQ queries are not synchronously enumerable. Use an async terminal operation once execution support is implemented.");
    }

    /// <inheritdoc />
    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}
