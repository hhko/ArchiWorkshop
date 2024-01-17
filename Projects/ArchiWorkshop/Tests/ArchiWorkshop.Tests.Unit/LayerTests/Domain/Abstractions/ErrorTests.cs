using ArchiWorkshop.Domains.Abstractions.Results;

namespace ArchiWorkshop.Tests.Unit.LayerTests.Domain.Abstractions;

public class ErrorTests
{
    private const string InvalidOperationExceptionMessage = "This was invalid operation";
    private const string ArgumentExceptionMessage = "Invalid argument";
    //private const string NotFoundExceptionMessage = "Not found";

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

    [Fact]
    public void FromException_ShouldContain_ExceptionMessage()
    {
        // Arrange
        //  public InvalidOperationException(string? message)
        var invalidOperationException = new InvalidOperationException(InvalidOperationExceptionMessage);

        // Act
        var error = Error.FromException(invalidOperationException);

        // Assert
        error.Code.Should().Be(nameof(InvalidOperationException));
        error.Message.Should().Contain(InvalidOperationExceptionMessage);
    }

    [Fact]
    public void FromException_ShouldContain_InnerExceptionMessage()
    {
        // Arrange
        //  public InvalidOperationException(string? message, Exception? innerException)
        var invalidOperationException = new InvalidOperationException(InvalidOperationExceptionMessage, new ArgumentException(ArgumentExceptionMessage));

        // Act
        var error = Error.FromException(invalidOperationException);

        // Assert
        error.Code.Should().Be(nameof(InvalidOperationException));
        error.Message.Should().Contain(InvalidOperationExceptionMessage, ArgumentExceptionMessage);
    }

    [Fact]
    public void FromException_ShouldContainAll_InnerExceptionsMessages()
    {
        // Arrange
        //   public AggregateException(params Exception[] innerExceptions) 
        var aggregateException = new AggregateException
        (
            new InvalidOperationException(InvalidOperationExceptionMessage),
            new ArgumentException(ArgumentExceptionMessage)
            //new ArgumentException(ArgumentExceptionMessage),
            //new NotFoundException(NotFoundExceptionMessage)
        );

        // Act
        var error = Error.FromException(aggregateException);

        // Assert
        error.Code.Should().Be(nameof(AggregateException));
        error.Message.Should().ContainAll(InvalidOperationExceptionMessage, ArgumentExceptionMessage); //, NotFoundExceptionMessage);
    }

    [Fact]
    public void Operator_ShouldString_FromCode()
    {
        // Arrang
        var error = Error.FromException(new InvalidOperationException(InvalidOperationExceptionMessage));

        // Act
        string code = error;

        // Assert
        code.Should().Be(nameof(InvalidOperationException));
    }
}
