﻿using System.Reflection;

namespace ArchiWorkshop.Adapters.WebApi;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}