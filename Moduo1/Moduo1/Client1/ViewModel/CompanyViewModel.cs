using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Client1.Command;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace Client1.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {
       
        #region propertyFields

        private string loggedInUser = "";
        public string selectedUserForEdit ="";

        private string usernameLogin;        //login
        private string passwordLogin;

        private string usernameAddUser;        //add user
        private string passwordAddUser;

        private string pi_username_admin;             //admin personal info
        private string pi_lastname_admin;
        private string pi_email_admin;
        private string pi_password_admin;
        private string pi_name_admin;

        private string ae_username_admin;             //admin personal info
        private string ae_lastname_admin;
        private string ae_email_admin;
        private string ae_password_admin;
        private string ae_name_admin;
        private string ae_roleComboBox_admin;
        private string aeRoleAdmin;
        private int aeRoleAdminIdx;

        private string ee_lastname_admin;           //admin edit employee
        private string ee_username_admin;
        private string ee_email_admin;
        private string ee_password_admin;
        private string ee_name_admin;
        private string ee_roleComboBox_admin;
        private string eeRoleAdmin;
        private int eeRoleAdminIdx;

        public ObservableCollection<string> EeEmployeeList { get; set; }     
        private string eeEmployeeAdmin;

        public ObservableCollection<string> EmployeeListAdmin { get; set; }

        #endregion

        /// <summary>
        /// private constructor
        /// </summary>
        public CompanyViewModel()
        {
        }
        public string LoggedInUser
        {
            get
            {
                return loggedInUser;
            }

            set
            {
                loggedInUser = value;
            }
        }
        
        #region UI Notification

        public event PropertyChangedEventHandler PropertyChanged;
        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion UI Notification

        #region On Property Change Fields
        public string UsernameLogin
        {
            get
            {
                return usernameLogin;
            }

            set
            {
                usernameLogin = value;
                OnPropertyChanged("username_login");
            }
        }
        public string PasswordLogin
        {
            get
            {
                return passwordLogin;
            }

            set
            {
                passwordLogin = value;
                OnPropertyChanged("password_login");
            }
        }

        public string UsernameAddUser
        {
            get
            {
                return usernameAddUser;
            }

            set
            {
                usernameAddUser = value;
                OnPropertyChanged("username_AddUser");
            }
        }
        public string PasswordAddUser
        {
            get
            {
                return passwordAddUser;
            }

            set
            {
                passwordAddUser = value;
                OnPropertyChanged("password_AddUser");
            }
        }

        public string PiUsernameAdmin
        {
            get
            {
                return pi_username_admin;
            }

            set
            {
                pi_username_admin = value;
                OnPropertyChanged("pi_username_admin");
            }
        }
        public string PiPasswordAdmin
        {
            get
            {
                return pi_password_admin;
            }

            set
            {
                pi_password_admin = value;
                OnPropertyChanged("pi_password_admin");
            }
        }
        public string PiNameAdmin
        {
            get
            {
                return pi_name_admin;
            }

            set
            {
                pi_name_admin = value;
                OnPropertyChanged("pi_name_admin");
            }
        }
        public string PiLastnameAdmin
        {
            get
            {
                return pi_lastname_admin;
            }

            set
            {
                pi_lastname_admin = value;
                OnPropertyChanged("pi_lastname_admin");
            }
        }
        public string PiEmailAdmin
        {
            get
            {
                return pi_email_admin;
            }

            set
            {
                pi_email_admin = value;
                OnPropertyChanged("pi_email_admin");
            }
        }
        public string AePasswordAdmin
        {
            get
            {
                return ae_password_admin;
            }

            set
            {
                ae_password_admin = value;
                OnPropertyChanged("ae_password_admin");
            }
        }
        public string AeUsernameAdmin
        {
            get
            {
                return ae_username_admin;
            }

            set
            {
                ae_username_admin = value;
                OnPropertyChanged("ae_username_admin");
            }
        }
        public string AeNameAdmin
        {
            get
            {
                return ae_name_admin;
            }

            set
            {
                ae_name_admin = value;
                OnPropertyChanged("ae_name_admin");
            }
        }
        public string AeLastnameAdmin
        {
            get
            {
                return ae_lastname_admin;
            }

            set
            {
                ae_lastname_admin = value;
                OnPropertyChanged("ae_lastname_admin");
            }
        }
        public string AeEmailAdmin
        {
            get
            {
                return ae_email_admin;
            }

            set
            {
                ae_email_admin = value;
                OnPropertyChanged("ae_email_admin");
            }
        }
        public string AeRoleComboBoxAdmin
        {
            get
            {
                return ae_roleComboBox_admin;
            }

            set
            {
                ae_roleComboBox_admin = value;
                OnPropertyChanged("ae_roleComboBox_admin");
            }
        }

        public string AeRoleAdmin
        {
            get
            {
                return aeRoleAdmin;
            }

            set
            {
                aeRoleAdmin = value;
                OnPropertyChanged("AeRoleAdmin");
            }
        }
        public int AeRoleAdminIdx
        {
            get
            {
                return aeRoleAdminIdx;
            }

            set
            {
                aeRoleAdminIdx = value;
                OnPropertyChanged("AeRoleAdminIdx");
            }
        }
        public string EeUsernameAdmin
        {
            get
            {
                return ee_username_admin;
            }

            set
            {
                ee_username_admin = value;
                OnPropertyChanged("ee_username_admin");
            }
        }
        public string EePasswordAdmin
        {
            get
            {
                return ee_password_admin;
            }

            set
            {
                ee_password_admin = value;
                OnPropertyChanged("ee_password_admin");
            }
        }
        public string EeNameAdmin
        {
            get
            {
                return ee_name_admin;
            }

            set
            {
                ee_name_admin = value;
                OnPropertyChanged("ee_name_admin");
            }
        }
        public string EeLastnameAdmin
        {
            get
            {
                return ee_lastname_admin;
            }

            set
            {
                ee_lastname_admin = value;
                OnPropertyChanged("ee_lastname_admin");
            }
        }
        public string EeEmailAdmin
        {
            get
            {
                return ee_email_admin;
            }

            set
            {
                ee_email_admin = value;
                OnPropertyChanged("ee_email_admin");
            }
        }
        public string EeRoleComboBoxAdmin
        {
            get
            {
                return ee_roleComboBox_admin;
            }

            set
            {
                ee_roleComboBox_admin = value;
                OnPropertyChanged("ee_roleComboBox_admin");
            }
        }

        public string EeRoleAdmin
        {
            get
            {
                return eeRoleAdmin;
            }

            set
            {
                eeRoleAdmin = value;
                OnPropertyChanged("EeRoleAdmin");
            }
        }
        public int EeRoleAdminIdx
        {
            get
            {
                return eeRoleAdminIdx;
            }

            set
            {
                eeRoleAdminIdx = value;
                OnPropertyChanged("EeRoleAdminIdx");
            }
        }
        
        public string EeEmployeeAdmin
        {
            get { return eeEmployeeAdmin; }
            set
            {
                eeEmployeeAdmin = value;
                OnPropertyChanged("EeEmployeeAdmin");
            }
        }
        #endregion

        #region Private Commands
        private ICommand editPersonalInfo;
        private ICommand login;
        private ICommand addUser;
        private ICommand closeWindow;
        private ICommand adminAddUser;
        private ICommand adminEditUser;
        private ICommand adminEditPi;
        #endregion

        #region Public Commands
        public ICommand Login
        {
            get
            {
                return login ?? (login = new RelayCommand(param => LoginExecution(param)));
            }
        }
        public ICommand AddUser
        {
            get
            {
                return addUser ?? (addUser = new RelayCommand(param => AddUserExecution(param)));
            }
        }

        public ICommand CloseWindow
        {
            get
            {
                return closeWindow ?? (closeWindow = new RelayCommand(param => CloseWindowExecution(param)));
            }
        }

        public ICommand AdminEditPi
        {
            get
            {
                return adminEditPi ?? (adminEditPi = new RelayCommand(param => AdminEditPiExecution(param)));
            }
        }

        public ICommand AdminAddUser
        {
            get
            {
                return adminAddUser ?? (adminAddUser = new RelayCommand(param => AdminAddUserExecution(param)));
            }
        }
        public ICommand AdminEditUser
        {
            get
            {
                return adminEditUser ?? (adminEditUser = new RelayCommand(param => AdminEditUserExecution(param)));
            }
        }

       
        #endregion

        #region CommandExecution (Reciever)
        private void AddUserExecution(object param)
        {
            User u = new User();
            Context wrap = Context.getInstance();
            u.Username = UsernameAddUser;                  //Dodavanje usera - za punjenje baze
            u.Password = PasswordAddUser;

            wrap.proxy.AddUser(u);
            wrap.subwin.Close();
        }
        
        private void LoginExecution(object param)
        {
            Context wrap = Context.getInstance();
            MainWindow win = ((MainWindow)wrap.mw);

            User us = new User();
            us = wrap.proxy.Login(UsernameLogin, PasswordLogin);

            if (us == null)
            {
                win.Close();
            }
            else
            {
                switch (us.Role)
                {
                    case Roles.CEO:
                        AdminWindow adminWin = new AdminWindow();
                        
                        adminWin.Show();

                        adminWin.pi_username_admin.Text = us.Username;          //personal info
                        loggedInUser = us.Username;
                        adminWin.pi_name_admin.Text = us.Name;
                        adminWin.pi_lastname_admin.Text = us.LastName;
                        adminWin.pi_password_admin.Text = us.Password;
                        adminWin.pi_email_admin.Text = us.Email;

                        adminWin.ae_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee
                        adminWin.ee_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));
                        adminWin.ee_roleComboBox_admin.SelectedIndex = 4;

                        //wrap.mw.Close();
                        wrap.subwin = adminWin;
                        break;
                    case Roles.HR:
                    case Roles.PO:
                        break;
                    case Roles.SM:
                        EmployeeWindow empWin = new EmployeeWindow(us);
                        empWin.Show();
                        wrap.mw.Close();
                        break;
                }
            }
        }
       
        private void AdminEditPiExecution(object param)
        {
            User userEdit = new User();
            User oldUser = new User();
            oldUser.Username = loggedInUser;

            Context wrap = Context.getInstance();

            userEdit.Name = PiNameAdmin;
            userEdit.LastName = PiLastnameAdmin;
            userEdit.Password = PiPasswordAdmin;
            userEdit.Email = PiEmailAdmin;

            wrap.proxy.EditUser(oldUser, userEdit);
            //wrap.subwin.Close();
        }

        private void AdminAddUserExecution(object param)
        {
            Context wrap = Context.getInstance();
            AdminWindow win = ((AdminWindow)wrap.subwin);

            User u1 = new User();
            u1.Username = AeUsernameAdmin;
            u1.Name = AeNameAdmin;
            u1.LastName = AeLastnameAdmin;
            u1.Password = AePasswordAdmin;
            u1.Email = AeEmailAdmin;
            u1.Role = (Roles)AeRoleAdminIdx;

            wrap.proxy.AddUser(u1);

            win.ee_listOfEmployees_admin.Items.Clear();

            win.ae_username_admin.Clear();
            win.ae_password_admin.Clear();
            win.ae_name_admin.Clear();
            win.ae_lastname_admin.Clear();
            win.ae_email_admin.Clear();

            foreach (User usr in wrap.proxy.GetAllEmployees())
            {
                win.ee_listOfEmployees_admin.Items.Add(usr.Username);
            }   
        }

        private void AdminEditUserExecution(object param)
        {
            Context wrap = Context.getInstance();
            AdminWindow win = ((AdminWindow)wrap.subwin);

            User userEdit = new User();
            User oldUser = new User();
            oldUser.Username = selectedUserForEdit;

            userEdit.Name = EeNameAdmin;
            userEdit.LastName = EeLastnameAdmin;
            userEdit.Password = EePasswordAdmin;
            userEdit.Email = EeEmailAdmin;
            userEdit.Role = (Roles)EeRoleAdminIdx;

            wrap.proxy.EditUser(oldUser, userEdit);

            win.ae_roleComboBox_admin.SelectedIndex = 4;

            win.ee_listOfEmployees_admin.Items.Clear();
            foreach (User usr in wrap.proxy.GetAllEmployees())
            {
                win.ee_listOfEmployees_admin.Items.Add(usr.Username);
            }   
            //wrap.subwin.Close();
        }

        private void CloseWindowExecution(object param)
        {
            Context wrap = Context.getInstance();
            wrap.subwin.Close();
        }
        #endregion
    }
}

