using System;
using System.IO;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string installDirectory = (AppDomain.CurrentDomain.BaseDirectory);
        public static string backupconfigFile = installDirectory + "config.txt";
        public static string backupConfigBase = "backuptype, ,backuplocation, ,username, ,password, ,";
        public MainWindow()
        {
            InitializeComponent();
            if (!File.Exists(backupconfigFile))
            {
                File.Create(backupconfigFile);
                StreamWriter sw = new StreamWriter(backupconfigFile);
                sw.Write(backupConfigBase);
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
