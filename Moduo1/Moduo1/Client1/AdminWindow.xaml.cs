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
        public AdminWindow()
        {
            InitializeComponent();

            Context wrapper = Context.getInstance();
            wrapper.subwin = this;
            this.DataContext = wrapper.cvm;
          
        }

        private void addEmployee_Click(object sender, RoutedEventArgs e)    
        {
            User u1 = new User();
            u1.Username = textBox3.Text;
            u1.Name = textBox3_Copy2.Text;
            u1.LastName = textBox3_Copy3.Text;
            u1.Password = textBox3_Copy.Text;
            u1.Email = textBox3_Copy1.Text;
            u1.Role = (Roles)roleComboBox.SelectedIndex;

            MainWindow.proxy.AddUser(u1);   
        }

        private void listOfEmployees_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User u = new User();
            u = MainWindow.proxy.GetUser(listOfEmployees.SelectedItem.ToString());
            textBox2.Text = u.Username;
            textBox2_Copy3.Text = u.Name;
            textBox2_Copy4.Text = u.LastName;
            textBox2_Copy.Text = u.Password;
            textBox2_Copy1.Text = u.Email;

            listOfRolesChange.ItemsSource = Enum.GetNames(typeof(Roles));
            listOfRolesChange.SelectedIndex = 4;
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            User userEdit = new User();

            User u = new User();
            u = MainWindow.proxy.GetUser(listOfEmployees.SelectedItem.ToString());

            userEdit.Username = textBox2.Text;
            userEdit.Name = textBox2_Copy3.Text;
            userEdit.LastName = textBox2_Copy4.Text;
            userEdit.Password = textBox2_Copy.Text;
            userEdit.Email = textBox2_Copy1.Text;
            userEdit.Role = (Roles)listOfRolesChange.SelectedIndex;

            MainWindow.proxy.EditUser(u, userEdit);
        }
  
    }
}
