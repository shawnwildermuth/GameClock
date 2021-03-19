using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameClock
{
  /// <summary>
  /// Interaction logic for SettingsWindow.xaml
  /// </summary>
  public partial class SettingsWindow : Window
  {
    private readonly Configuration _config;

    public SettingsWindow(Configuration config)
    {
      InitializeComponent();
      DataContext = config;
      _config = config;
    }

    private void fontButton_Click(object sender, RoutedEventArgs e)
    {
      var fontDialog = new System.Windows.Forms.FontDialog();
      fontDialog.Font = new Font(_config.FontFamily, _config.FontSize);
      if (fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        _config.FontSize = fontDialog.Font.Size;
        _config.FontFamily = fontDialog.Font.FontFamily.Name;
        _config.FontWeight = fontDialog.Font.Bold ? 800 : 400;
      }
    }

    private void foregroundColorButton_Click(object sender, RoutedEventArgs e)
    {
      var colorDialog = new System.Windows.Forms.ColorDialog();
      colorDialog.Color = ColorTranslator.FromHtml(_config.TextColor);
      if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        _config.TextColor = ColorTranslator.ToHtml(colorDialog.Color);
      }
    }

    private void backgroundColorButton_Click(object sender, RoutedEventArgs e)
    {
      var colorDialog = new System.Windows.Forms.ColorDialog();
      colorDialog.Color = ColorTranslator.FromHtml(_config.BackgroundColor);
      if (colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
      {
        _config.BackgroundColor = ColorTranslator.ToHtml(colorDialog.Color);
      }
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
      _config.Save();
      Close();
    }
  }
}
