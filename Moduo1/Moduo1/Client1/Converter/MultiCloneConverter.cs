using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Client1.Converter
{
    public class MultiCloneConverter : IMultiValueConverter
    {
        /// <summary>
        /// Convert function
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType">Traget type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns>Converted value</returns>
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values == null)
            {
                return null;
            }

            return values.Clone();
        }

        /// <summary>
        /// Convert back function
        /// </summary>
        /// <param name="value">Value to convert</param>
        /// <param name="targetType">Traget type</param>
        /// <param name="parameter">Parameter</param>
        /// <param name="culture">Culture</param>
        /// <returns>Converted value</returns>
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
