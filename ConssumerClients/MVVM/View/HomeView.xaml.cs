using ConssumerClients.Clients.ClientsEnum;
using ConssumerClients.Clients.CommandLineClients;
using ConssumerClients.Clients.HttpAnzlyzeAngular;
using ConssumerClients.Clients.SocketClients;
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

namespace ConssumerClients.MVVM.View
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : UserControl
    {
        public HomeView()
        {
            InitializeComponent();
        }
        private void TcpBtnClick(object sender, RoutedEventArgs e)
        {
            SocetPropertiesWindow socetwindow = new SocetPropertiesWindow(ConsumerClientsEnum.Tcp);
            socetwindow.Show();
            Application.Current.MainWindow.Close();
        }

        private void WebSocketBtnClick(object sender, RoutedEventArgs e)
        {
            SocetPropertiesWindow socetwindow = new SocetPropertiesWindow(ConsumerClientsEnum.WebSocket);
            socetwindow.Show();
            Application.Current.MainWindow.Close();

        }
        private void UdpBtnClick(object sender, RoutedEventArgs e)
        {
            SocetPropertiesWindow socetwindow = new SocetPropertiesWindow(ConsumerClientsEnum.Udp);
            socetwindow.Show();
            Application.Current.MainWindow.Close();

        }
        private void HttpBtnClick(object sender, RoutedEventArgs e)
        {
            SocetPropertiesWindow socetwindow = new SocetPropertiesWindow(ConsumerClientsEnum.Http);
            socetwindow.Show();
            Application.Current.MainWindow.Close();
        }
        private void MongodbpBtnClick(object sender, RoutedEventArgs e)
        {
            CommandLineMongodbServerListener mongoServer = new CommandLineMongodbServerListener();
            Task.Factory.StartNew(() => mongoServer.ActivateMongodbListener());
        }
        private void PythontHttpBtnClick(object sender, RoutedEventArgs e)
        {
            SocetPropertiesWindow socetwindow = new SocetPropertiesWindow(ConsumerClientsEnum.PythonHttp);
            socetwindow.Show();
            Application.Current.MainWindow.Close();
          //  PythonScriptActivate pythonScript = new PythonScriptActivate(8080, @"C:\Users\gilie\PycharmProjects\pandas\Controller.py");
          //  Task.Factory.StartNew(() => pythonScript.ActivateServer());
        }
    }
}
