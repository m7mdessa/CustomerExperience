﻿using System.Reflection;

namespace CustomerExperience.Core.Application
{
    public static class AssemblyReference
    {
        public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
    }

}
