using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace GameClock
{
  //todo font converter and other settings to config
  public class ColorConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      System.Drawing.Color color;

      if (value is System.Drawing.Color)
      {
        color = (System.Drawing.Color)value;
      }
      else if (value is string)
      {
        color = System.Drawing.ColorTranslator.FromHtml((string)value);
      }
      else
      {
        throw new InvalidOperationException("Failed to convert color");
      }

      return new System.Windows.Media.SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      System.Windows.Media.SolidColorBrush brush = value as System.Windows.Media.SolidColorBrush;
      System.Drawing.Color color = System.Drawing.Color.FromArgb(brush.Color.A, brush.Color.R, brush.Color.G, brush.Color.B);
      return color;
    }
  }
}
