using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Data;
using Athena.Data.Books;
using Castle.Core.Internal;

namespace Athena.Converters
{
    public class EmptyListVisibilityConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {

            if (value is IEnumerable enumerable) {
                if (enumerable.IsNullOrEmpty()) {
                    return Visibility.Visible;
                }
                else {
                    return Visibility.Collapsed;
                }
            }
            else {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
