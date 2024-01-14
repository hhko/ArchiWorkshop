using ArchiWorkshop.Domains.AggregateRoots.Users.ValueObjects;
using Bogus;

namespace ArchiWorkshop.Tests.Unit.LayerTests.Domain.Users.ValueObjects;

public class EmailTests
{
    [Fact]
    public void Email_ShouldCreate_WhenValidInput()
    {
        // Arrange
        var faker = new Faker();

        // Act
        var actual = Email.Create("hello@world.com");

        // Assert
        actual.Should().NotBeNull();
        actual.Value.Should().BeAssignableTo<Email>();
    }

    //[Fact]
    //public void Email_ShouldCreate_WhenValidInput()
    //{
    //    // Arrange
    //    var faker = new Faker();

    //    // Act
    //    var actual = Email.Create(faker.Person.Email);

    //    // Assert
    //    actual.Should().NotBeNull();
    //    actual.Value.Should().BeAssignableTo<Email>();
    //}

    // Email_ShouldNotCreate_WhenInvalidInput
    // 공백
    // 길이
    // 형식
}
