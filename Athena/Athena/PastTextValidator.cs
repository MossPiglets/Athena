using System.Linq;
using System.Windows;

namespace Athena {
    public class PastTextValidator {
        public static void AllowPastOnlyNumbers(DataObjectPastingEventArgs e) {
            if (e.DataObject.GetDataPresent(typeof(string))) {
                string text = (string) e.DataObject.GetData(typeof(string));
                if (text.Any(a => !char.IsDigit(a))) {
                    e.CancelCommand();
                }
            }
            else {
                e.CancelCommand();
            }
        }
    }
}