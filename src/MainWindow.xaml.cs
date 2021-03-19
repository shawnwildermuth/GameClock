using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameClock.ViewModels;

namespace GameClock
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    MainViewModel _vm = new MainViewModel();
    public MainWindow()
    {
      InitializeComponent();

      this.DataContext = _vm;
      this.Left = _vm.Configuration.WindowLeft;
      this.Top = _vm.Configuration.WindowTop;
    }

    private void Window_Activated(object sender, EventArgs e)
    {
      _vm.StartTimer();
    }

    protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
    {
      base.OnMouseLeftButtonDown(e);
      this.DragMove();
    }

    private void MenuItemSettings_Click(object sender, RoutedEventArgs e)
    {
      new SettingsWindow(_vm.Configuration).ShowDialog();
    }

    private void MenuItemClose_Click(object sender, RoutedEventArgs e) => this.Close();

    System.Windows.Media.Brush ColorToBrush(System.Drawing.Color color)
    {
      var converter = Resources.Values.OfType<ColorConverter>().FirstOrDefault();
      SolidColorBrush solidColorBrush = (SolidColorBrush)converter.Convert(color, typeof(SolidColorBrush), null, null);
      return solidColorBrush;
    }

    private void Window_LocationChanged(object sender, EventArgs e)
    {
      _vm.Configuration.WindowLeft = this.Left;
      _vm.Configuration.WindowTop = this.Top;
      _vm.Configuration.Save();
    }

    private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
      new SettingsWindow(_vm.Configuration).ShowDialog();
      e.Handled = true;
    }
  }
}
