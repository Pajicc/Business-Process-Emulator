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
using System.Collections.Specialized;
using System.Windows.Forms;

namespace Client1.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {

        #region propertyFields

        public ObservableCollection<User> employeeList { get; set; }

        public ObservableCollection<Project> projects { get; set; }

        public ObservableCollection<Project> activeProjects { get; set; }
        public ObservableCollection<Project> notActiveProjects { get; set; }

        public ObservableCollection<string> partnerCompanies { get; set; }

        public User currentUser = new User();

        private string loggedInUser = "";
        public string selectedUserForEdit = "";

        private string usernameLogin;        //login
        private string passwordLogin;

        private string usernameAddUser;        //add user
        private string passwordAddUser;

        private string pi_username;             //personal info
        private string pi_lastname;
        private string pi_email;
        private string pi_password;
        private string pi_name;
        private string pi_from;
        private string pi_to;

        // ** ADMIN **
        private string ae_username_admin;             //add employee
        private string ae_lastname_admin;
        private string ae_email_admin;
        private string ae_password_admin;
        private string ae_name_admin;
        private string ae_roleComboBox_admin;
        private string aeRoleAdmin;
        private int aeRoleAdminIdx;

        private string ee_lastname_admin;           //edit employee
        private string ee_username_admin;
        private string ee_email_admin;
        private string ee_password_admin;
        private string ee_name_admin;
        private string ee_roleComboBox_admin;
        private string eeRoleAdmin;
        private int eeRoleAdminIdx;

        // ** PRODUCT OWNER **
        private string ap_name_po;           //add project
        private string ap_desc_po;
        private string ap_from_po;
        private string ap_to_po;


        public ObservableCollection<string> EeEmployeeList { get; set; }
        private string eeEmployeeAdmin;

        public ObservableCollection<string> EmployeeListAdmin { get; set; }

        #endregion

        /// <summary>
        /// private constructor
        /// </summary>
        public CompanyViewModel()
        {
            employeeList = new ObservableCollection<User>();
            projects = new ObservableCollection<Project>();
            activeProjects = new ObservableCollection<Project>();
            notActiveProjects = new ObservableCollection<Project>();
            partnerCompanies = new ObservableCollection<string>();
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

        public string PiUsername
        {
            get
            {
                return pi_username;
            }

            set
            {
                pi_username = value;
                OnPropertyChanged("pi_username");
            }
        }
        public string PiPassword
        {
            get
            {
                return pi_password;
            }

            set
            {
                pi_password = value;
                OnPropertyChanged("pi_password");
            }
        }
        public string PiName
        {
            get
            {
                return pi_name;
            }

            set
            {
                pi_name = value;
                OnPropertyChanged("pi_name");
            }
        }
        public string PiLastname
        {
            get
            {
                return pi_lastname;
            }

            set
            {
                pi_lastname = value;
                OnPropertyChanged("pi_lastname");
            }
        }
        public string PiEmail
        {
            get
            {
                return pi_email;
            }

            set
            {
                pi_email = value;
                OnPropertyChanged("pi_email");
            }
        }
        public string PiFrom
        {
            get
            {
                return pi_from;
            }

            set
            {
                pi_from = value;
                OnPropertyChanged("pi_from");
            }
        }
        public string PiTo
        {
            get
            {
                return pi_to;
            }

            set
            {
                pi_to = value;
                OnPropertyChanged("pi_to");
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

        public string ApNamePo
        {
            get
            {
                return ap_name_po;
            }

            set
            {
                ap_name_po = value;
                OnPropertyChanged("ap_name_po");
            }
        }
        public string ApDescPo
        {
            get
            {
                return ap_desc_po;
            }

            set
            {
                ap_desc_po = value;
                OnPropertyChanged("ap_desc_po");
            }
        }
        public string ApFromPo
        {
            get
            {
                return ap_from_po;
            }

            set
            {
                ap_from_po = value;
                OnPropertyChanged("ap_from_po");
            }
        }
        public string ApToPo
        {
            get
            {
                return ap_to_po;
            }

            set
            {
                ap_to_po = value;
                OnPropertyChanged("ap_to_po");
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
        private ICommand poAddProject;
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

        public ICommand EditPi
        {
            get
            {
                return editPersonalInfo ?? (editPersonalInfo = new RelayCommand(param => EditPiExecution(param)));
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
        public ICommand PoAddProject
        {
            get
            {
                return poAddProject ?? (poAddProject = new RelayCommand(param => PoAddProjectExecution(param)));
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

            if (UsernameLogin == "" || PasswordLogin == "")
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (wrap.proxy.Login(UsernameLogin, PasswordLogin))
                {
                    currentUser = wrap.proxy.GetUser(UsernameLogin);

                    loggedInUser = currentUser.Username;

                    employeeList.Clear();
                    foreach (User u in wrap.proxy.GetAllOnlineUsers())
                    {
                        employeeList.Add(u);
                    }

                    PiUsername = currentUser.Username;      //Personal Info
                    PiPassword = currentUser.Password;
                    PiName = currentUser.Name;
                    PiLastname = currentUser.LastName;
                    PiEmail = currentUser.Email;
                    PiFrom = currentUser.WorkTimeStart;
                    PiFrom = currentUser.WorkTimeEnd;

                    projects.Clear();
                    notActiveProjects.Clear();
                    activeProjects.Clear();

                    foreach (Project proj in wrap.proxy.GetAllProjects())   //iz baze dodaj u observable liste sve projekte
                    {
                        if (!projects.Contains(proj))
                            projects.Add(proj);

                        switch (proj.State)
                        {
                            case States.approved:
                                activeProjects.Add(proj);
                                break;
                            case States.notApproved:
                                notActiveProjects.Add(proj);
                                break;
                        }

                    }

                    switch (currentUser.Role)
                    {
                        case Roles.CEO:
                            AdminWindow adminWin = new AdminWindow();

                            adminWin.Show();

                            adminWin.ae_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee
                            adminWin.ee_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));
                            adminWin.ee_roleComboBox_admin.SelectedIndex = 4;

                            adminWin.allEmployeesGrid.Items.Refresh();

                            partnerCompanies.Clear();
                            foreach (string comp in wrap.proxy.GetAllPartnerCompanies(LoggedInUser))
                            {
                                partnerCompanies.Add(comp);
                            }
                            //wrap.mw.Close();
                            wrap.subwin = adminWin;
                            break;
                        case Roles.HR:
                            HumanResourceWindow hrWin = new HumanResourceWindow();
                            hrWin.Show();
                            wrap.subwin = hrWin;
                            break;
                        case Roles.SM:
                        case Roles.PO:
                            ProductOwnerWindow poWin = new ProductOwnerWindow();
                            poWin.Show();
                            wrap.subwin = poWin;
                            break;
                        case Roles.Employee:
                            EmployeeWindow empWin = new EmployeeWindow();
                            empWin.Show();
                            wrap.mw.Close();
                            break;
                    }
                }
            }
        }

        private void EditPiExecution(object param)
        {
            User newUser = new User();

            Context wrap = Context.getInstance();
            AdminWindow win = ((AdminWindow)wrap.subwin);

            newUser = wrap.proxy.GetUser(LoggedInUser); //stare vrednosti

            if (PiName != null)              //ako su izmenjene, zameni ih
                newUser.Name = PiName;
            if (PiLastname != null)
                newUser.LastName = PiLastname;
            if (PiPassword != null)
                newUser.Password = PiPassword;
            if (PiEmail != null)
                newUser.Email = PiEmail;
            if (PiFrom != null)
                newUser.WorkTimeStart = PiFrom;
            if (PiTo != null)
                newUser.WorkTimeEnd = PiTo;

            wrap.proxy.EditUser(newUser);

            employeeList.Clear();
            foreach (User u in wrap.proxy.GetAllOnlineUsers())
            {
                employeeList.Add(u);
            }
            win.allEmployeesGrid.Items.Refresh();

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

            userEdit = wrap.proxy.GetUser(selectedUserForEdit);

            if (EeNameAdmin != null)
                userEdit.Name = EeNameAdmin;
            if (EeLastnameAdmin != null)
                userEdit.LastName = EeLastnameAdmin;
            if (EePasswordAdmin != null)
                userEdit.Password = EePasswordAdmin;
            if (EeEmailAdmin != null)
                userEdit.Email = EeEmailAdmin;
            userEdit.Role = (Roles)EeRoleAdminIdx;

            wrap.proxy.EditUser(userEdit);

            win.ae_roleComboBox_admin.SelectedIndex = 4;

            win.ee_listOfEmployees_admin.Items.Clear();
            foreach (User usr in wrap.proxy.GetAllEmployees())
            {
                win.ee_listOfEmployees_admin.Items.Add(usr.Username);
            }

            employeeList.Clear();
            foreach (User u in wrap.proxy.GetAllOnlineUsers())
            {
                employeeList.Add(u);
            }
            win.allEmployeesGrid.Items.Refresh();
            //wrap.subwin.Close();
        }

        private void PoAddProjectExecution(object param)
        {
            Context wrap = Context.getInstance();
            ProductOwnerWindow win = ((ProductOwnerWindow)wrap.subwin);

            Project p = new Project();
            p.Name = ApNamePo;
            p.Description = ApDescPo;
            p.StartTime = ApFromPo;
            p.EndTime = ApToPo;
            p.Po = LoggedInUser;

            wrap.proxy.CreateProject(p);

            if (!projects.Contains(p))
                projects.Add(p);

            notActiveProjects.Add(p);

            win.ap_name_po.Clear();
            win.ap_desc_po.Clear();
            win.ap_from_po.Clear();
            win.ap_to_po.Clear();
        }

        private void CloseWindowExecution(object param)
        {
            Context wrap = Context.getInstance();
            wrap.subwin.Close();
        }
        #endregion
    }
}

