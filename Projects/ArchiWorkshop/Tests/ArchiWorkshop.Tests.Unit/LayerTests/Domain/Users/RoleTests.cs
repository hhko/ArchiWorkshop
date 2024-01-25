using ArchiWorkshop.Domains.AggregateRoots.Users.Enumerations;

namespace ArchiWorkshop.Tests.Unit.LayerTests.Domain.Users;

public class RoleTests
{
    [Fact]
    public void Contains_ShouldBeTrue_WhenValidId()
    {
        // Arrange
        Role customer = Role.Customer;

        // Act
        bool actual = Role.Contains(customer.Id);

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void Contains_ShouldBeFalse_WhenInvalidId()
    {
        // Act
        bool actual = Role.Contains(-1);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void FromId_ShouldBeTrue_WhenValid()
    {
        // Arrange
        Role? role = Role.FromId(1);

        // Act
        bool actual = role == Role.Customer;

        // Assert
        actual.Should().BeTrue();
    }
}
