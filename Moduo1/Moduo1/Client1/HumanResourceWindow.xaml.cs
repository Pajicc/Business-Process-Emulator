using Common;
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

namespace Client1
{
    /// <summary>
    /// Interaction logic for HumanResourceWindow.xaml
    /// </summary>
    public partial class HumanResourceWindow : Window
    {
        public HumanResourceWindow()
        {
            InitializeComponent();

            Context wrapper = Context.GetInstance();
            wrapper.Subwin = this;
            this.DataContext = wrapper.Cvm;

            foreach (User usr in wrapper.Proxy.GetAllEmployees())
            {
                ee_listOfEmployees_admin.Items.Add(usr.Username);
            }

        }

        private void Ee_listOfEmployees_admin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User u = new User();

            Context wrap = Context.GetInstance();

            if (ee_listOfEmployees_admin.SelectedIndex != -1 || ee_listOfEmployees_admin.SelectedItem != null)
            {
                u = wrap.Proxy.GetUser(ee_listOfEmployees_admin.SelectedItem.ToString());

                ee_username_admin.Text = u.Username;
                ee_name_admin.Text = u.Name;
                ee_lastname_admin.Text = u.LastName;
                ee_password_admin.Text = u.Password;
                ee_email_admin.Text = u.Email;
                ee_roleComboBox_admin.SelectedIndex = 4;

                wrap.Cvm.SelectedUserForEdit = ee_username_admin.Text;
            }
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
