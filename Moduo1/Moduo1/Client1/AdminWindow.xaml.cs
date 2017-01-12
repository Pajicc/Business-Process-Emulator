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

            sendReqButton.IsEnabled = false;

            foreach (User usr in wrapper.proxy.GetAllEmployees())
            {
                ee_listOfEmployees_admin.Items.Add(usr.Username);
            }

            List<string> allOutComp = wrapper.outsourcingProxy.GetAllOutsourcingCompanies();

            foreach (string comp in allOutComp)
            {
                outsourcingCompanies.Items.Add(comp);
            } 
        }

        private void ee_listOfEmployees_admin_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            User u = new User();

            Context wrap = Context.getInstance();

            if (ee_listOfEmployees_admin.SelectedIndex != -1 || ee_listOfEmployees_admin.SelectedItem != null)
            {
                u = wrap.proxy.GetUser(ee_listOfEmployees_admin.SelectedItem.ToString());

                ee_username_admin.Text = u.Username;
                ee_name_admin.Text = u.Name;
                ee_lastname_admin.Text = u.LastName;
                ee_password_admin.Text = u.Password;
                ee_email_admin.Text = u.Email;
                ee_roleComboBox_admin.SelectedIndex = 4;

                wrap.cvm.selectedUserForEdit = ee_username_admin.Text;
            }
               
        }

        private void outsourcingCompanies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sendReqButton.IsEnabled = true;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void DataGrid_DoubleMouseClick(object sender, MouseButtonEventArgs e)
        {
            Context wrap = Context.getInstance();

            userStories.Items.Clear();

            foreach(string userStory in wrap.proxy.GetAllUserStories(projectsGrid.SelectedItem as Project))
            {
                userStories.Items.Add(userStory);
            }
            
        }

    }
}
