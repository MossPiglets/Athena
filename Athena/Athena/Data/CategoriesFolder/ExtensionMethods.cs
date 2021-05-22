using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Athena.Data.CategoriesFolder
{
    public static class ExtensionMethods
    {
            public static string GetDescription(this Category c)
            {
            return ((DescriptionAttribute[])c.Name.GetType()
                                                .GetMember(c.Name.ToString())
                                                .FirstOrDefault()
                                                .GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
            }
    }
}
