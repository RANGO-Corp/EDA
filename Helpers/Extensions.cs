using System;
using System.Linq;
using System.Reflection;

namespace Alere.Helpers
{
    public static class Extensions
    {
        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            return value
                        .GetType()
                        .GetMember(value.ToString())
                        .First()
                        .GetCustomAttribute<T>()
                    ;
        }
    }
}