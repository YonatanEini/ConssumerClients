using ConssumerClients.AlertMessagesEnum;
using ConssumerClients.Clients.ClientsEnum;
using ConssumerClients.Clients.ClientsFactory;
using ConssumerClients.Clients.SocketClients;
using MaterialDesignThemes.Wpf;
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
using System.Windows.Shapes;

namespace ConssumerClients
{
    /// <summary>
    /// Interaction logic for SocetPropertiesWindow.xaml
    /// </summary>
    public partial class SocetPropertiesWindow : Window
    {
        public ConsumerClientsEnum ConsumerClientType { get; set; }

        public SocetPropertiesWindow(ConsumerClientsEnum client)
        {
            InitializeComponent();
            this.ConsumerClientType = client;
            FormTitle.Text = $"{this.ConsumerClientType} Server Properties";
        }
        public bool IsDarkTheme { get; set; }
        private readonly PaletteHelper paletHelper = new PaletteHelper();
        /// <summary>
        /// Dark and Light Mode Button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToogleTheme_Click(object sender, RoutedEventArgs e)
        {
            ITheme theme = paletHelper.GetTheme();
            if (IsDarkTheme = theme.GetBaseTheme() == BaseTheme.Dark)
            {
                IsDarkTheme = false;
                theme.SetBaseTheme(Theme.Light);
            }
            else
            {
                IsDarkTheme = true;
                theme.SetBaseTheme(Theme.Dark);
            }
            paletHelper.SetTheme(theme);
        }
        private void ExitApp(object sender, RoutedEventArgs e)
        {
            MainWindow consumerClientWindow = new MainWindow();
            Application.Current.MainWindow = consumerClientWindow;
            consumerClientWindow.Show();
            this.Close();

        }
        /// <summary>
        /// To enable window drag on mouse press
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private async void SubmitPropertisBtn_Click(object sender, RoutedEventArgs e)
        {
            //ip address from the form
            string ipAddress = SocketIp.Text;
            //port number from the form
            _ = int.TryParse(SocketPort.Text, out int portNumber);
            if (ipAddress != " " && portNumber != 0)
            {
                ConsumerCientsFactory clientsFactory = ConsumerCientsFactory.GetInstance();
                SocketClientBase client = clientsFactory.GetClient(this.ConsumerClientType, portNumber, ipAddress);
                AlertsMessagEnum alertType = await Task.Factory.StartNew(() => client.ActivateServer());
                DiaglogBox diaglogBoxWindow = new DiaglogBox(alertType, ConsumerClientType);
                HandleAlertMessage(diaglogBoxWindow, alertType);
            }
            else
            {
                DiaglogBox diaglogBoxWindow = new DiaglogBox(AlertsMessagEnum.Error, ConsumerClientType);
                diaglogBoxWindow.Show();
            }

        }
        private void HandleAlertMessage(DiaglogBox diaglogBoxWindow, AlertsMessagEnum alertType)
        {
            if (alertType == AlertsMessagEnum.ok)
            {
                MainWindow consumerClientWindow = new MainWindow();
                Application.Current.MainWindow = consumerClientWindow;
                consumerClientWindow.Show();
                diaglogBoxWindow.Show();
                this.Close();
            }
            else
            {
                //Error or Exist Parameters 
                diaglogBoxWindow.Show();
            }
        }
    }
}
