using Mono.Cecil;

namespace ArchiWorkshop.Tests.Unit.Abstractions.Extensions.CustomRules;

public sealed class DefinesStaticMethod(string methodName) : ICustomRule
{
    public bool MeetsRule(TypeDefinition type)
    {
        return type
            .Methods
            .Any(methodDefinition => methodDefinition.Name == methodName && methodDefinition.IsStatic);
    }
}
