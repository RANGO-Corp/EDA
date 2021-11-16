using System;

#nullable enable

namespace Alere.Helpers
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
    public class StyleAttribute : Attribute
    {
        public string? Severity { get; set; }

        public StyleAttribute() { }
    }
}