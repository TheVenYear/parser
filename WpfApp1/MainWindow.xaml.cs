using System;
using System.Collections.Generic;
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
using ParserLibrary.Parsers;
using ParserLibrary.Core;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ParserWorker<IEnumerable<string>> parser;
        public MainWindow()
        {
            InitializeComponent();
            parser = new ParserWorker<IEnumerable<string>>(new AvitoParser());
            parser.OnNewData += Parser_OnNewData;
        }

        private void Parser_OnNewData(object arg1, IEnumerable<string> arg2)
        {
            foreach (var item in arg2)
            {
                hello.Items.Add(item);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(firstIndex.Text, out var begin) && int.TryParse(secondIndex.Text, out var end))
            {
                parser.Settings = new AvitoParserSettings() { FirstIndex = begin, SecondIndex = end };
                hello.Items.Clear();
                parser.Work();
            }
            else
            {
                MessageBox.Show("Неверно заданы страницы");
            }

        }
    }
}
