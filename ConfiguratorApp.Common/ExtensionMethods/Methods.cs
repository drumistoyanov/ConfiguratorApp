using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace ConfiguratorApp.Common.ExtensionMethods
{
    public static class Methods
    {
        public static string GetDisplayName(this Enum enumValue)
        {
            return enumValue.GetType()?
                        .GetMember(enumValue.ToString())?
                        .First()?
                        .GetCustomAttribute<DisplayAttribute>()?
                        .Name;
        }
    }
}
