using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Graphics;

namespace MyApp.Converter
{
    internal class StatusColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string status)
            {
                switch (status.ToLower())
                {
                    case "pending":
                        return Color.Parse("#E27816");
                    case "failed":
                        return Color.Parse("#DE3730");
                    case "success":
                        return Color.Parse("#65B96D");

                }
            }

            return Color.Parse("Default");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
