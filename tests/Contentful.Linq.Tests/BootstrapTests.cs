using System.Linq.Expressions;

namespace Contentful.Linq.Tests;

public sealed class BootstrapTests
{
    [Fact]
    public void QueryableCapturesComposedExpression()
    {
        var query = new ContentfulQueryable<Article>()
            .Where(article => article.Slug == "hello-world")
            .Take(5);

        Assert.Equal(typeof(Article), query.ElementType);
        Assert.Contains(nameof(Queryable.Where), query.Expression.ToString(), StringComparison.Ordinal);
        Assert.Contains(nameof(Queryable.Take), query.Expression.ToString(), StringComparison.Ordinal);
    }

    [Fact]
    public void TranslatorReturnsDiagnosticQueryModel()
    {
        Expression expression = new ContentfulQueryable<Article>()
            .Where(article => article.Slug == "hello-world")
            .Expression;

        var model = new ContentfulExpressionTranslator().Translate(expression);

        Assert.Contains("hello-world", model.ExpressionText, StringComparison.Ordinal);
    }

    [Fact]
    public void ProviderCanCreateNonGenericQueryable()
    {
        var source = new ContentfulQueryable<Article>();

        var query = source.Provider.CreateQuery(source.Expression);

        Assert.Equal(typeof(Article), query.ElementType);
    }

    private sealed class Article
    {
        public string Slug { get; init; } = "";
    }
}
