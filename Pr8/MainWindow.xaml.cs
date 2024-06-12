using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Serialization;

namespace Pr8
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Themes.ApplyTheme();
            Languages.ApplyLanguage();

            Card card = new Card();
            card.Content = "123";
            card.Width = 200;
            card.Height = 100;
            card.HorizontalAlignment = HorizontalAlignment.Center;
            card.VerticalAlignment = VerticalAlignment.Center;

            Content = card;
        }
    }
}

public class Languages
{
    public static readonly Dictionary<string, string> Russian = new Dictionary<string, string>
    {
        {"Hello", "Привет"},
        {"Goodbye", "Пока"}
    };

    public static readonly Dictionary<string, string> English = new Dictionary<string, string>
    {
        {"Hello", "Hello"},
        {"Goodbye", "Goodbye"}
    };

    public static void ApplyLanguage()
    {
        Application.Current.Resources.MergedDictionaries.Add(new ResourceDictionary { Source = new Uri("pack://application:,,,/Languages/Russian.xaml") });
    }
}

public class DataSerializer
{
    public static T Deserialize<T>(string xml) where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StringReader reader = new StringReader(xml))
        {
            return (T)serializer.Deserialize(reader);
        }
    }

    public static string Serialize<T>(T obj) where T : class
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        using (StringWriter writer = new StringWriter())
        {
            serializer.Serialize(writer, obj);
            return writer.ToString();
        }
    }
}