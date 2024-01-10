using System.Reflection;

namespace ArchiWorkshop.Domains;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}
