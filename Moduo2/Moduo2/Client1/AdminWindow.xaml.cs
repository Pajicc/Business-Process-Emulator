﻿using System;
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
using System.Globalization;

namespace Client2
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        User user = new User();

        public AdminWindow(User u)
        {
            InitializeComponent();

            user = u;

            textBox.Text = u.Username;          //personal info
            textBox_Copy2.Text = u.Name;
            textBox_Copy3.Text = u.LastName;
            textBox_Copy.Text = u.Password;
            textBox_Copy1.Text = u.Email;
            tb1.Text = u.WorkTimeStartHour.ToString();
            tb2.Text = u.WorkTimeStartMin.ToString();
            tb3.Text = u.WorkTimeEnd.ToString();
            tb4.Text = u.WorkTimeEndMin.ToString();

            roleComboBox.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee

            foreach (User usr in MainWindow.proxy.GetAllLogedUsers())
            {
                listOfEmployees.Items.Add(usr.Username);
            }           
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

        private void editPersonalInfo_Click(object sender, RoutedEventArgs e)
        {
            User userEdit = new User();

            userEdit.Name = textBox_Copy2.Text;
            userEdit.LastName = textBox_Copy3.Text;
            userEdit.Password = textBox_Copy.Text;
            userEdit.Email = textBox_Copy1.Text;
            userEdit.WorkTimeStartHour = int.Parse(tb1.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeStartMin = int.Parse(tb2.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeEnd = int.Parse(tb3.Text, CultureInfo.InvariantCulture);
            userEdit.WorkTimeEndMin = int.Parse(tb4.Text, CultureInfo.InvariantCulture);

            MainWindow.proxy.EditUser(user, userEdit);
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
           

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            List<User> employees = new List<User>();
            employees = MainWindow.proxy.GetAllLogedUsers();
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
