using ArchiWorkshop.Domains.Abstractions.BaseTypes;
using ArchiWorkshop.Tests.Unit.Abstractions.Extensions;

namespace ArchiWorkshop.Tests.Unit.ArchitectureTests;

public sealed class ValueObjectTests
{
    [Fact]
    public void ValueObjects_IsImuutable()
    {
        // Arrange
        var doaminAssembly = Domains.AssemblyReference.Assembly;
        var testUnitAssembly = Unit.AssemblyReference.Assembly;

        // Act
        var actual = Types
            .InAssemblies([doaminAssembly, testUnitAssembly])
            .That()
            .Inherit(typeof(ValueObject))
            .Should()
            .BeImmutable()
            .GetResult();

        // Assert
        actual.IsSuccessful.Should().BeTrue();
    }

    [Theory]
    //[InlineData("Validate")]
    [InlineData("Create")]
    public void ValueObjects_ShouldDefineMethod(string methodName)
    {
        //Arrange
        var assembly = Domains.AssemblyReference.Assembly;

        //Act
        var result = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(ValueObject))
            .Should()
            .DefinesStaticMethod(methodName)
            .GetResult();

        //Assert
        result.IsSuccessful.Should().BeTrue();
    }
}

public class MutableValueObject : ValueObject
{
    //public int Value { get; set; }
    public int Value { get; private set; }

    public void Increment(int value)
    {
        Value = value;
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;    
    }
}
