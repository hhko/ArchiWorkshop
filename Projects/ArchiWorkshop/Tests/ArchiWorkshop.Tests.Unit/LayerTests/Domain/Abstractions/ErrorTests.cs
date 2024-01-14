using ArchiWorkshop.Domains.Abstractions.Results;

namespace ArchiWorkshop.Tests.Unit.LayerTests.Domain.Abstractions;

public class ErrorTests
{
    [Fact]
    public void ThrowIfErrorNone_ShouldThrowAnException_WhenErrorIsNone()
    {
        // Arrange
        var error = Error.None;

        // Act
        Action actual = FluentActions.Invoking(error.ThrowIfErrorNone);

        // Assert
        actual
            .Should()
            .ThrowExactly<InvalidOperationException>()
            .Which
            .Message
            .Should()
            .Be("Provided error is Error.None");
    }
}
