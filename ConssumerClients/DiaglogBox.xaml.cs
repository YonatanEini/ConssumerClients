using ConssumerClients.AlertMessagesEnum;
using ConssumerClients.Clients.ClientsEnum;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for DiaglogBox.xaml
    /// </summary>
    public partial class DiaglogBox : Window
    {
        public string AlertMessage { get; set; }
        public DiaglogBox(string message)
        {
            InitializeComponent();
            textBox.Text = message;
        }
        public DiaglogBox(AlertsMessagEnum alertType, ConsumerClientsEnum clientType)
        {
            InitializeComponent();
            AlertMessageFactory msgFactory = AlertMessageFactory.GetInstance();
            this.AlertMessage = msgFactory.GetAlertMessage(alertType, clientType);
            textBox.Text = this.AlertMessage;
        }
        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
