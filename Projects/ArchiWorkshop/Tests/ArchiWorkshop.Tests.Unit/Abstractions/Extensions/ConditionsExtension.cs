using ArchiWorkshop.Tests.Unit.Abstractions.Extensions.CustomRules;

namespace ArchiWorkshop.Tests.Unit.Abstractions.Extensions;

internal static class ConditionsExtension
{
    public static ConditionList DefinesStaticMethod(this Conditions conditions, string methodName)
    {
        return conditions.MeetCustomRule(new DefinesStaticMethod(methodName));
    }
}
