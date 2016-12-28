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
using Common;
using System.ServiceModel;

namespace Client1
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow(User u)
        {
            InitializeComponent();

            textBox.Text = u.Username;
            textBox_Copy.Text = u.Password;
            textBox_Copy1.Text = u.Email;
            textBox_Copy4.Text = u.WorkTimeStart.ToString();
            textBox_Copy3.Text = u.WorkTimeEnd.ToString();
            roleComboBox.DataContext = Enum.GetNames(typeof(Roles));
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)
        {
            User u = new User();
            u.Username = textBox3.Text;
            u.Password = textBox3_Copy.Text;
            u.Email = textBox3_Copy1.Text;
            u.Role = (Roles)roleComboBox.SelectedItem;


            using (Client1Proxy proxy = new Client1Proxy(MainWindow.binding, new EndpointAddress(new Uri(MainWindow.address))))
            {
               proxy.AddUser(u);
           }
        }
    }
}
