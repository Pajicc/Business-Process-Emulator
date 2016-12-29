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
        public static Client1Proxy proxy;

        public MainWindow()
        {
            InitializeComponent();

            NetTcpBinding binding = new NetTcpBinding();
            string address = "net.tcp://localhost:9999/CompanyService";
            proxy = new Client1Proxy(binding, new EndpointAddress(new Uri(address)));
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User u = new User();
            
            u = proxy.Login(textbox1.Text, textbox2.Password);

            if (u == null)
            {
                this.Close();
            }
            else
            {
                switch (u.Role)
                {
                    case Roles.CEO:
                        AdminWindow adminWin = new AdminWindow(u);
                        adminWin.Show();
                        this.Close();
                        break;
                    case Roles.HR:
                    case Roles.PO:
                        break;
                    case Roles.SM:
                        EmployeeWindow empWin = new EmployeeWindow(u);
                        empWin.Show();
                        this.Close();
                        break;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            AddUsers addUsers = new AddUsers();
            addUsers.Show();
        }
    }
}
