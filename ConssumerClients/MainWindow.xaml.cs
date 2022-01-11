using ConssumerClients.Clients.ClientsEnum;
using ConssumerClients.MVVM.ViewModel;
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
using System.Windows.Threading;

namespace ConssumerClients
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetCurrentDate();
            _ = Task.Factory.StartNew(() => UpdateHour());
        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            DragMove();
        }
        private async Task UpdateHour()
        {
            while (true)
            {
                _ = Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
                  {
                      currentHour.Text = DateTime.Now.ToString("HH:mm:ss");
                  }));
                await Task.Delay(1000);
            }
        }
        private void SetCurrentDate()
        {
            _ = Dispatcher.Invoke(DispatcherPriority.Normal, new Action(() =>
            {
                currentDate.Text = DateTime.UtcNow.Date.ToString();
            }));
        }
    }
}
