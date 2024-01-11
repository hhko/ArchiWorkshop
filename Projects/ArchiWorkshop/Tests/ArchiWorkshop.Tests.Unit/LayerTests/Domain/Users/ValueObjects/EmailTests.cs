using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;

namespace ArchiWorkshop.Tests.Unit.LayerTests.Domain.Users.ValueObjects;

public class EmailTests
{
    // Email_ShouldNotCreate_WhenInvalidInput
    [Fact]
    public void Email_ShouldCreate_WhenValidInput()
    {
        // Arrange

        // Act
        var actual = Email.Create("hello@xyz.com");

        // Assert
        actual.Should().NotBeNull();
    }
}
