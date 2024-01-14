using System.Reflection;

namespace ArchiWorkshop.Applications;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
