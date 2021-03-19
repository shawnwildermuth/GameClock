using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using GalaSoft.MvvmLight;

namespace GameClock.ViewModels
{
  public class MainViewModel : ViewModelBase
  {
    DispatcherTimer _timer;

    string _time;
    private Configuration _config;

    public MainViewModel()
    {
      Configuration = Configuration.Load();
      InitTimer();
    }

    public Configuration Configuration
    {
      get => _config;
      set => Set(ref _config, value);
    }

    public string TimeProperty
    {
      get => _time;
      set { Set(ref _time, value); }
    }

    void InitTimer()
    {
      _timer = new DispatcherTimer();
      _timer.Interval = TimeSpan.FromMilliseconds(Configuration.Period);
      _timer.Tick += (s, e) => TimeProperty = DateTime.Now.ToString(Configuration.Format);
    }

    public void StartTimer()
    {
      _timer.IsEnabled = true;
    }

  }
}
