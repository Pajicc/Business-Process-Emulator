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
using System.Globalization;

namespace Client2
{
    /// <summary>
    /// Interaction logic for EmployeeWindow.xaml
    /// </summary>
    public partial class EmployeeWindow : Window
    {
        User user = new User();
       // int start = 0;
        public EmployeeWindow(User u)
        {
            InitializeComponent();
            user = u;

            textBox_Copy5.Text = user.Username;
            textBox_Copy2.Text = user.Name;
            textBox.Text = user.LastName;
            textBox_Copy.Text = user.Password;
            textBox_Copy1.Text = user.Email;
            textBox_Copy4.Text = user.WorkTimeStartHour.ToString();
            textBox1.Text = user.WorkTimeStartMin.ToString();
            textBox_Copy3.Text = user.WorkTimeEnd.ToString();

          //  start = int.Parse(textBox_Copy4.Text, CultureInfo.InvariantCulture);
        }

        private void EditEmployee_Click(object sender, RoutedEventArgs e)
        {
            /*
            textBox_Copy2 //name
            textBox         //lastname
            textBox_Copy    //pass
                textBox_Copy1 //email
                textBox_Copy4 //from,
                    textBox_Copy3 //to
             */

            User userEdit = new User();

            userEdit.Username = textBox_Copy5.Text;
            userEdit.Name = textBox_Copy2.Text;
            userEdit.LastName = textBox.Text;
            userEdit.Password = textBox_Copy.Text;
            userEdit.Email = textBox_Copy1.Text;
            userEdit.Role = Roles.Employee;
            userEdit.WorkTimeStartHour = int.Parse(textBox_Copy4.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeStartMin = int.Parse(textBox1.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeEnd = int.Parse(textBox_Copy3.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeEndMin = int.Parse(textBox_Copy6.Text, CultureInfo.InvariantCulture);

            MainWindow.proxy.EditUser(user, userEdit);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<User> employees = new List<User>();
            employees = MainWindow.proxy.GetAllEmployees();
            for (int i = 0; i < employees.Count; i++)
                listBox.Items.Add(employees[i].Username);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.proxy.LogOut(user.Username, user.Password);
            this.Close();
        }
    }
}
