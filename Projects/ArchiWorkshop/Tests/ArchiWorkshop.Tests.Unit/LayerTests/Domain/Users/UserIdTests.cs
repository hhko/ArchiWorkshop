using System.ComponentModel;
using System.Drawing;

namespace ArchiWorkshop.Domains.AggregateRoots.Users;

public class UserIdTests
{
    [Fact]
    public void ConvertStringToEntity()
    {
        // Arrange
        UserId userId = UserId.New();

        // Act
        UserId actualUseId = (UserId)TypeDescriptor.GetConverter(typeof(UserId)).ConvertFrom(userId.Value.ToString());

        // Assert
        (actualUseId == userId).Should().BeTrue();
    }
}
