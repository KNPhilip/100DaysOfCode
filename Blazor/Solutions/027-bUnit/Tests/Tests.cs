using Bunit;
using BlazorApp.Pages;

namespace Tests;

public sealed class Tests : BunitContext
{
    [Fact]
    public void FindCounterPageWelcomeText()
    {
        // Arrange
        RenderedComponent<Counter> cut = Render<Counter>();

        // Act

        // Assert
        cut.Find("h1").MarkupMatches("<h1>Counter</h1>");
    }

    [Fact]
    public void CounterShouldIncrementWhenClicked()
    {
        // Arrange
        RenderedComponent<Counter> cut = Render<Counter>();

        // Act
        cut.Find("button").Click();

        // Assert
        cut.Find("p").MarkupMatches("<p role=\"status\">Current count: 1</p>");
    }
}