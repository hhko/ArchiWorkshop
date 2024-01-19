using System.Reflection;

namespace ArchiWorkshop.Adapters.Presentation;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
