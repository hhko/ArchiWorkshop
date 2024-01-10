using System.Reflection;

namespace ArchiWorkshop.Tests.Unit;

internal sealed class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
