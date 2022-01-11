using ConssumerClients.Clients.HttpAnzlyzeAngular;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace ConssumerClients.MVVM.View
{
    /// <summary>
    /// Interaction logic for ClientsGuiView.xaml
    /// </summary>
    public partial class ClientsGuiView : UserControl
    {
        public ClientsGuiView()
        {
            InitializeComponent();
        }

        private void ActivateAngularBtn_Click(object sender, RoutedEventArgs e)
        {
            AnguarAppActivate angularApp = new AnguarAppActivate();
            Task.Factory.StartNew(() => angularApp.StartingAngularAppProcessAsync());
        }

        private void ActivateCompassBtn_Click(object sender, RoutedEventArgs e)
        {
            //appsettings
            _ = Process.Start(@"C:\Users\gilie\AppData\Local\MongoDBCompass\MongoDBCompass.exe");
        }
    }
}
