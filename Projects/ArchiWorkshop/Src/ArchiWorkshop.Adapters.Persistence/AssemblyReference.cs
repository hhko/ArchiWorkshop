using System.Reflection;

namespace ArchiWorkshop.Adapters.Persistence;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
