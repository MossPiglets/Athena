using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Athena.EnumLocalizations {
    public class EnumSorter {
        public static List<TEnum> GetSortedByDescriptions<TEnum>() where TEnum : Enum {
            return Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
                .OrderBy(a => TypeDescriptor.GetConverter(a).ConvertTo(a, typeof(string))?.ToString())
                .ToList();
        }
    }
}