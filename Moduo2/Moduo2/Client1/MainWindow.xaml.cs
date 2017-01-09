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
using System.Globalization;

namespace Client2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public static Client1Proxy proxy;
       // User user = new User();
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
            /*
            u.Username = textbox1.Text;       //Dodavanje usera - za punjenje baze
            u.Password = textbox2.Password;
            proxy.AddUser(u);
            */
            
            u = proxy.Login(textbox1.Text, textbox2.Password);

          

            if (u == null)
            {
                this.Close();
            }
            else
            {
                if ( u.Role == Roles.HR)
                {
                    AdminWindow adminWin = new AdminWindow(u);
                    adminWin.Show();
                    this.Close();
                }
                else if (u.Role == Roles.CEO)
                {
                    CeoWindow CeoWin = new CeoWindow(u);
                    CeoWin.Show();
                    this.Close();


                }
                else if (u.Role == Roles.Employee)
                {
                    EmployeeWindow empWin = new EmployeeWindow(u);
                    empWin.Show();
                    this.Close();

                }
                else if (u.Role == Roles.TL)
                {
                    TeamLeader empWin = new TeamLeader(u);
                    empWin.Show();
                    this.Close();
                }


                DateTime dt = DateTime.Now;
                int trenutno = dt.Minute;
                int h = dt.Hour;
                int starth = u.WorkTimeStartHour;
                int startno = u.WorkTimeStartMin;
                if ((trenutno - startno > 15) || (h != starth))
                {
                    int kasnjenje = trenutno - startno;
                    int kasnjenje1 = h - starth;
                    MessageBox.Show("Zakasnili ste " + kasnjenje1 + " h, i "+ kasnjenje + "min.");
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
