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
        /// <summary>
        /// rezult field
        /// </summary>
        public User user { get; set; }

        /// <summary>
        /// currency field
        /// </summary>
        public ObservableCollection<User> usersList { get; set; }

        #region propertyFields

        private string usernameLogin;        //login
        private string passwordLogin;

        private string usernameAddUser;        //add user
        private string passwordAddUser;

        private string pi_username_admin;             //admin personal info
        private string pi_lastname_admin;
        private string pi_email_admin;
        private string pi_password_admin;
        private string pi_name_admin;

        private string textBox3;            //edit employee
        private string textBox3_Copy3;
        private string textBox3_Copy2;
        private string textBox3_Copy1;
        private string textBox3_Copy;

        #endregion

        /// <summary>
        /// private constructor
        /// </summary>
        public CompanyViewModel()
        {
            usersList = new ObservableCollection<User>();
            user = new User();
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

        #endregion

        #region Private Commands
        private ICommand editPersonalInfo;
        private ICommand login;
        private ICommand addUser;
        private ICommand addEmployee;
        private ICommand editEmployee;
        private ICommand closeWindow;
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
        /*public ICommand EditPersonalInfo
        {
            get
            {
                return editPersonalInfo ?? (editPersonalInfo = new RelayCommand(param => EditPersonalInfoExecution(param)));
            }
        }

        
        public ICommand AddEmployee
        {
            get
            {
                return addEmployee ?? (addEmployee = new RelayCommand(param => AddEmployeeExecution(param)));
            }
        }
        public ICommand EditEmployee
        {
            get
            {
                return editEmployee ?? (editEmployee = new RelayCommand(param => EditEmployeeExecution(param)));
            }
        }*/

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
                        adminWin.pi_name_admin.Text = us.Name;
                        adminWin.pi_lastname_admin.Text = us.LastName;
                        adminWin.pi_password_admin.Text = us.Password;
                        adminWin.pi_email_admin.Text = us.Email;

                        adminWin.roleComboBox.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee

                        foreach (User usr in wrap.proxy.GetAllEmployees())
                        {
                            adminWin.listOfEmployees.Items.Add(usr.Username);
                        }           
                        wrap.mw.Close();
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

            Context wrap = Context.getInstance();

            userEdit.Name = PiNameAdmin;
            userEdit.LastName = PiLastnameAdmin;
            userEdit.Password = PiPasswordAdmin;
            userEdit.Email = PiEmailAdmin;

            wrap.proxy.EditUser(user, userEdit);
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

