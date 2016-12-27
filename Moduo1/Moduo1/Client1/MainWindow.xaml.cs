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
using System.ServiceModel;
using Common;

namespace Client1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LoginForm win = new LoginForm();
            win.ShowDialog();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/CompanyService";

            using (Client1Proxy proxy = new Client1Proxy(binding, new EndpointAddress(new Uri(address))))
            {
                User u = new User();
                u = proxy.Login(textbox1.Text, textbox2.Password);

                if (u == null)
                {
                    this.Close();
                }
                else
                {
                    if (u.Role == Roles.CEO || u.Role == Roles.HR)
                    {
                        Window1 win1 = new Window1();
                        win1.Show();
                        this.Close();
                    }
                    if (u.Role == Roles.Employee)
                    {
                        Window2 win2 = new Window2();
                        win2.Show();
                        this.Close();
                    }
                }
            }

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
