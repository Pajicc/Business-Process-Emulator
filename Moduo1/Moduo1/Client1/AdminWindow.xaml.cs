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

            /*List<string> allOutComp = wrapper.outsourcingProxy.GetAllOutsourcingCompanies();

            foreach (string comp in allOutComp)
            {
                outsourcingCompanies.Items.Add(comp);
            } */
            outsourcingCompanies.Items.Add("KompanijaA");
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

        private void sendReqButton_Click(object sender, RoutedEventArgs e)
        {
            Context wrap = Context.getInstance();

            if (!wrap.cvm.partnerCompanies.Contains(outsourcingCompanies.SelectedItem.ToString()))
            {
                bool app = wrap.outsourcingProxy.PartnershipRequest(outsourcingCompanies.SelectedItem.ToString());

                if (app)
                {
                    MessageBox.Show("Approved!");
                    wrap.proxy.AddPartnerCompany(wrap.cvm.currentUser, outsourcingCompanies.SelectedItem.ToString());   //dodavanje u bazu

                    wrap.cvm.partnerCompanies.Clear();  //ocisti bind listu 

                    foreach (string comp in wrap.proxy.GetAllPartnerCompanies(wrap.cvm.currentUser))       //iscitaj iz baze i ubaci u listu
                    {
                        if (!wrap.cvm.partnerCompanies.Contains(comp))
                            wrap.cvm.partnerCompanies.Add(comp);
                        partnerCompaniesComboBox.Items.Refresh();
                    }

                }
                else
                {
                    MessageBox.Show("Not approved!");
                }
            }
            else
            {
                MessageBox.Show("Companies already have partnership");
            }

           
                
        }

        private void outsourcingCompanies_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            sendReqButton.IsEnabled = true;
        }

        private void approveProject_Click(object sender, RoutedEventArgs e)
        {
            Context wrap = Context.getInstance();

            if(partnerCompanies_Copy1.SelectedItem != null)
            {
                Project p = partnerCompanies_Copy1.SelectedItem as Project;

                p.State = States.approved;
                p.HiringCompany = wrap.cvm.currentUser.Company;
                wrap.proxy.UpdateProject(p);

                wrap.cvm.activeProjects.Add(p);         //dodaj u aktivne
                wrap.cvm.notActiveProjects.Remove(p);   //obrisi iz neaktivnih
                wrap.cvm.projects.Add(p);                //dodaj u sve projekte za tog konkretnoh CEO(kompaniju)

                projectsGrid.Items.Refresh();
            }
            
        }

        private void sendProject_Click(object sender, RoutedEventArgs e)
        {
            Context wrap = Context.getInstance();

            if (partnerCompanies_Copy.SelectedItem != null)
            {
                Project p = partnerCompanies_Copy.SelectedItem as Project;

                //string company = wrap.proxy.GetCompany(wrap.cvm.LoggedInUser);      //vraca ime kompanije

                if (wrap.outsourcingProxy.SendProject(p.Name, p.Description, p.HiringCompany))
                {
                    p.State = States.inProgress;
                    wrap.proxy.UpdateProject(p);
                    wrap.cvm.activeProjects.Remove(p);
                }

                projectsGrid.Items.Refresh();
            }
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
