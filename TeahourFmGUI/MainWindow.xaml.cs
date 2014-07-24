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
using System.Reflection;

namespace TeahourFmGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MainWindow()
        {
            System.IO.FileInfo fi = new System.IO.FileInfo(System.IO.Path.GetFullPath(@"..\config\logger.config.xml"));
            log4net.Config.XmlConfigurator.Configure(fi);
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebObject wo = new WebObject("http://teahour.fm");
            List<string> downloadList = wo.GetFileAddress();
            string downloadStr = string.Empty;

            log.Info("Add each item in download list");
            foreach (var item in downloadList)
            {
                downloadStr += item;
                downloadStr += "\n";
            }
            log.Info("Add data to clipboard");
            Clipboard.SetDataObject(downloadStr);
        }
    }
}
