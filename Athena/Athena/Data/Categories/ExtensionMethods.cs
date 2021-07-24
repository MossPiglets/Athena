using System.ComponentModel;
using System.Linq;

namespace Athena.Data.Categories {
    public static class ExtensionMethods {
        public static string GetDescription(this Category c) {
            return ((DescriptionAttribute[]) c.Name.GetType()
                .GetMember(c.Name.ToString())
                .FirstOrDefault()
                .GetCustomAttributes(typeof(DescriptionAttribute), false))[0].Description;
        }
    }
}