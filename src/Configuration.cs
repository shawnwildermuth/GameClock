using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;

namespace GameClock
{
  public class Configuration : ViewModelBase
  {
    private const string ConfigFilePath = "GameClock.config.json";
    private string _textColor = "#80FFFFFF";
    private int _borderSize = 0;
    private string _backgroundColor = "#05000000";
    private string _format = "t";
    private int _period = 1000;
    private double _windowLeft = 0f;
    private double _windowTop = 0f;

    public int Period
    {
      get => _period;
      set => Set(ref _period, value);
    }

    public double WindowLeft
    {
      get => _windowLeft;
      set => Set(ref _windowLeft, value);
    }

    public double WindowTop
    {
      get => _windowTop;
      set => Set(ref _windowTop, value);
    }

    public string Format
    {
      get => _format;
      set
      {
        base.Set(ref _format, value);
      }
    }

    public string TextColor
    {
      get => _textColor;
      set
      {
        base.Set(ref _textColor, value);
      }
    }

    public float FontSize
    {
      get;
      set;
    } = 25f;

    public string FontFamily
    {
      get;
      set;
    } = "Source Sans Pro";

    public int FontWeight
    {
      get;
      set;
    } = 400;

    public int BorderThickness
    {
      get => _borderSize;
      set
      {
        base.Set(ref _borderSize, value);
      }
    }

    public string BackgroundColor
    {
      get => _backgroundColor;
      set
      {
        base.Set(ref _backgroundColor, value);
      }
    }

    public static Configuration Load()
    {
      try
      {
        if (File.Exists(ConfigFilePath))
        {
          var file = File.ReadAllText(ConfigFilePath);
          return JsonSerializer.Deserialize<Configuration>(file);
        }
      }
      catch
      {
        Console.WriteLine("Failed to read the configuration file.");
      }

      return new Configuration();
    }

    public void Save()
    {
      var json = JsonSerializer.Serialize(this, new JsonSerializerOptions() { WriteIndented = true });
      File.WriteAllText(ConfigFilePath, json);
    }

  }
}
