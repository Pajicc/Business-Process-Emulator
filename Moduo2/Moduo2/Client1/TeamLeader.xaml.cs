using Common;
using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace Client2
{
    /// <summary>
    /// Interaction logic for TeamLeader.xaml
    /// </summary>
    public partial class TeamLeader : Window
    {
        User user = new User();

        public TeamLeader(User u)
        {
            InitializeComponent();
            user = u;

            textBox_Copy5.Text = user.Username;
            textBox_Copy2.Text = user.Name;
            textBox.Text = user.LastName;
            textBox_Copy.Text = user.Password;
            textBox_Copy1.Text = user.Email;
            textBox_Copy4.Text = user.WorkTimeStartHour.ToString();
            textBox_Copy6.Text = user.WorkTimeStartMin.ToString();

            textBox_Copy3.Text = user.WorkTimeEnd.ToString();
            textBox_Copy7.Text = user.WorkTimeEndMin.ToString();

            List<int> ocene = new List<int>();
            ocene.Add(1);
            ocene.Add(2);
            ocene.Add(3);
            ocene.Add(5);
            ocene.Add(8);
            ocene.Add(11);
            ComboboxTezina.ItemsSource = ocene;
         
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
            userEdit.WorkTimeStartMin = int.Parse(textBox_Copy6.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeEnd = int.Parse(textBox_Copy3.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeEndMin = int.Parse(textBox_Copy7.Text, CultureInfo.InvariantCulture);

            MainWindow.proxy.EditUser(user, userEdit);
        }

        

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<User> employees = new List<User>();
            employees = MainWindow.proxy.GetAllLogedUsers();
            for (int i = 0; i < employees.Count; i++)
                listBox.Items.Add(employees[i].Username);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow.proxy.LogOut(user.Username, user.Password);
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
