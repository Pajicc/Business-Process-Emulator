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
using System.Threading;

namespace Client1.ViewModel
{
    public class CompanyViewModel : INotifyPropertyChanged
    {

        #region propertyFields

        public ObservableCollection<User> EmployeeList { get; set; }
        public ObservableCollection<Project> Projects { get; set; }
        public ObservableCollection<Project> ActiveProjects { get; set; }
        public ObservableCollection<Project> NotActiveProjects { get; set; }
        public ObservableCollection<Project> ProjectsAdmin { get; set; }
        public ObservableCollection<string> PartnerCompanies { get; set; }

        private Thread t;
        private Thread projT;

        private User currentUser = new User();

        private string loggedInUser = "";
        private string selectedUserForEdit = "";

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

        //pass change
        private string pc_password_change;

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
            EmployeeList = new ObservableCollection<User>();
            Projects = new ObservableCollection<Project>();
            ActiveProjects = new ObservableCollection<Project>();
            NotActiveProjects = new ObservableCollection<Project>();
            ProjectsAdmin = new ObservableCollection<Project>();
            PartnerCompanies = new ObservableCollection<string>();
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
        public string PcNewPassword
        {
            get
            {
                return pc_password_change;
            }

            set
            {
                pc_password_change = value;
                OnPropertyChanged("pc_password_change");
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
        private ICommand editPc;
        private ICommand sendRequest;
        private ICommand approveProject;
        private ICommand sendProject;
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

        public ICommand EditPc
        {
            get
            {
                return editPc ?? (editPc = new RelayCommand(param => EditPcExecution(param)));
            }
        }

        public ICommand SendRequest
        {
            get
            {
                return sendRequest ?? (sendRequest = new RelayCommand(param => SendRequestExecution(param)));
            }
        }

        public ICommand ApproveProject
        {
            get
            {
                return approveProject ?? (approveProject = new RelayCommand(param => ApproveProjectExecution(param)));
            }
        }
        public ICommand SendProject
        {
            get
            {
                return sendProject ?? (sendProject = new RelayCommand(param => SendProjectExecution(param)));
            }
        }

        public string SelectedUserForEdit
        {
            get
            {
                return selectedUserForEdit;
            }

            set
            {
                selectedUserForEdit = value;
            }
        }


        #endregion

        #region CommandExecution (Reciever)
        private void AddUserExecution(object param)
        {
            User u = new User();
            Context wrap = Context.GetInstance();
            u.Username = UsernameAddUser;                  //Dodavanje usera - za punjenje baze
            u.Password = PasswordAddUser;

            wrap.Proxy.AddUser(u);
            wrap.Subwin.Close();
        }

        private void LoginExecution(object param)
        {
            Context wrap = Context.GetInstance();
            MainWindow win = wrap.Mw as MainWindow;
            wrap.Mw = win;

            if (UsernameLogin == "" || PasswordLogin == "")
            {
                MessageBox.Show("Please enter username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (wrap.Proxy.Login(UsernameLogin, PasswordLogin))
                {
                    wrap.Mw.Close();

                    currentUser = wrap.Proxy.GetUser(UsernameLogin);

                    loggedInUser = currentUser.Username;

                    EmployeeList.Clear();
                    foreach (User u in wrap.Proxy.GetAllOnlineUsers())
                    {
                        EmployeeList.Add(u);
                    }

                    PiUsername = currentUser.Username;      //Personal Info
                    PiPassword = currentUser.Password;
                    PiName = currentUser.Name;
                    PiLastname = currentUser.LastName;
                    PiEmail = currentUser.Email;
                    PiFrom = currentUser.WorkTimeStart;
                    PiTo = currentUser.WorkTimeEnd;

                    Projects.Clear();               //za svakog korisnika posebno - DataGrid - svi projekti za tu kompaniju
                    NotActiveProjects.Clear();      //za sve korisnike isto, jednom kad se odobri, izbacuje se
                    ActiveProjects.Clear();         //za svakog posebno - Approved Projects

                    foreach (Project proj in wrap.Proxy.GetAllProjectsForUser(currentUser))   
                    {
                        if (!Projects.Contains(proj))
                        {
                            Projects.Add(proj);
                        }

                        if (proj.State == States.approved)
                        {
                            ActiveProjects.Add(proj);
                        }
                    }

                    foreach (Project p in wrap.Proxy.GetAllProjects())
                    {
                        if (p.State == States.notApproved)
                        {
                            NotActiveProjects.Add(p);
                        }
                    }

                    //thread za 6 meseci
                    t = new Thread(() => ProveraPass(currentUser));
                    t.SetApartmentState(ApartmentState.STA);
                    t.Start();

                    switch (currentUser.Role)
                    {
                        case Roles.CEO:
                            AdminWindow adminWin = new AdminWindow();

                            adminWin.Show();

                            adminWin.ae_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee
                            adminWin.ee_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));
                            adminWin.ee_roleComboBox_admin.SelectedIndex = 4;

                            adminWin.allEmployeesGrid.Items.Refresh();

                            PartnerCompanies.Clear();
                            foreach (string comp in wrap.Proxy.GetAllPartnerCompanies(currentUser))
                            {
                                PartnerCompanies.Add(comp);
                            }
                      
                            break;
                        case Roles.HR:
                            HumanResourceWindow hrWin = new HumanResourceWindow();
                            hrWin.Show();

                            hrWin.ae_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));    //add employee
                            hrWin.ee_roleComboBox_admin.ItemsSource = Enum.GetNames(typeof(Roles));
                            hrWin.ee_roleComboBox_admin.SelectedIndex = 4;

                            hrWin.allEmployeesGrid.Items.Refresh();
                            break;
                        case Roles.SM:
                            ScrumMasterWindow smWin = new ScrumMasterWindow();
                            smWin.Show();
                            projT = new Thread(() => CheckProjects(currentUser));
                            projT.SetApartmentState(ApartmentState.STA);
                            projT.Start();
                            break;
                        case Roles.PO:
                            ProductOwnerWindow poWin = new ProductOwnerWindow();
                            poWin.Show();
                            break;
                        case Roles.Employee:
                            EmployeeWindow empWin = new EmployeeWindow();
                            empWin.Show();
                            wrap.Mw.Close();
                            break;
                    }
                }
            }
        }

        private void EditPiExecution(object param)
        {
            User newUser = new User();

            Context wrap = Context.GetInstance();
            
            newUser = wrap.Proxy.GetUser(LoggedInUser); //stare vrednosti

            //ako su izmenjene, zameni ih
            if (PiName != null)
            {
                newUser.Name = PiName;
            }         
                
            if (PiLastname != null)
            {
                newUser.LastName = PiLastname;
            }
                
            if (PiPassword != null)
            {
                newUser.Password = PiPassword;
            }
                
            if (PiEmail != null)
            {
                newUser.Email = PiEmail;
            }
                
            if (PiFrom != null)
            {
                newUser.WorkTimeStart = PiFrom;
            }
                
            if (PiTo != null)
            {
                newUser.WorkTimeEnd = PiTo;
            }

            wrap.Proxy.EditUser(newUser);

            EmployeeList.Clear();
            foreach (User u in wrap.Proxy.GetAllOnlineUsers())
            {
                EmployeeList.Add(u);
            }
            //AdminWindow win = ((AdminWindow)wrap.subwin);
            //win.allEmployeesGrid.Items.Refresh();

        }

        private void AdminAddUserExecution(object param)
        {
            Context wrap = Context.GetInstance();
            AdminWindow win = wrap.Subwin as AdminWindow;

            User u1 = new User();
            u1.Username = AeUsernameAdmin;
            u1.Name = AeNameAdmin;
            u1.LastName = AeLastnameAdmin;
            u1.Password = AePasswordAdmin;
            u1.Email = AeEmailAdmin;
            u1.Role = (Roles)AeRoleAdminIdx;

            wrap.Proxy.AddUser(u1);

            win.ee_listOfEmployees_admin.Items.Clear();

            win.ae_username_admin.Clear();
            win.ae_password_admin.Clear();
            win.ae_name_admin.Clear();
            win.ae_lastname_admin.Clear();
            win.ae_email_admin.Clear();

            foreach (User usr in wrap.Proxy.GetAllEmployees())
            {
                win.ee_listOfEmployees_admin.Items.Add(usr.Username);
            }
        }

        private void AdminEditUserExecution(object param)
        {
            Context wrap = Context.GetInstance();
            AdminWindow win = wrap.Subwin as AdminWindow;

            User userEdit = new User();

            userEdit = wrap.Proxy.GetUser(SelectedUserForEdit);

            if (EeNameAdmin != null)
            {
                userEdit.Name = EeNameAdmin;
            }
                
            if (EeLastnameAdmin != null)
            {
                userEdit.LastName = EeLastnameAdmin;
            }
                
            if (EePasswordAdmin != null)
            {
                userEdit.Password = EePasswordAdmin;
            }
                
            if (EeEmailAdmin != null)
            {
                userEdit.Email = EeEmailAdmin;
            }
                
            userEdit.Role = (Roles)EeRoleAdminIdx;

            wrap.Proxy.EditUser(userEdit);

            win.ae_roleComboBox_admin.SelectedIndex = 4;

            win.ee_listOfEmployees_admin.Items.Clear();
            foreach (User usr in wrap.Proxy.GetAllEmployees())
            {
                win.ee_listOfEmployees_admin.Items.Add(usr.Username);
            }

            EmployeeList.Clear();
            foreach (User u in wrap.Proxy.GetAllOnlineUsers())
            {
                EmployeeList.Add(u);
            }
            win.allEmployeesGrid.Items.Refresh();
            //wrap.subwin.Close();
        }

        private void PoAddProjectExecution(object param)
        {
            Context wrap = Context.GetInstance();
            ProductOwnerWindow win = wrap.Subwin as ProductOwnerWindow;

            Project p = new Project();
            p.Name = ApNamePo;
            p.Description = ApDescPo;
            p.StartTime = ApFromPo;
            p.EndTime = ApToPo;
            p.Po = LoggedInUser;

            wrap.Proxy.CreateProject(p);

            if (!Projects.Contains(p))
            {
                Projects.Add(p);
            }

            NotActiveProjects.Add(p);

            win.ap_name_po.Clear();
            win.ap_desc_po.Clear();
            win.ap_from_po.Clear();
            win.ap_to_po.Clear();
        }

        private void CloseWindowExecution(object param)
        {
            Context wrap = Context.GetInstance();
            wrap.Proxy.LogOut(LoggedInUser);
            EmployeeList.Remove(currentUser);
            wrap.Subwin.Close();
            t.Suspend();                                //zatvaramo thread za check pass kada se korisnik izloguje

            if (currentUser.Role == Roles.SM)
            {
                projT.Suspend();                        //zatvaramo thread za check isteka projekta
            }

            MainWindow win = new MainWindow();
            win.Show();
            wrap.Mw = win;
        }

        private void EditPcExecution(object param)
        {
            Context wrap = Context.GetInstance();
            wrap.Proxy.ChangePass(PiUsername, PiPassword, PcNewPassword);
            wrap.ChangePass.Close();
        }

        private void SendRequestExecution(object param)
        {
            Context wrap = Context.GetInstance();
            AdminWindow win = wrap.Subwin as AdminWindow;

            if (!PartnerCompanies.Contains(win.outsourcingCompanies.SelectedItem.ToString()))
            {
                bool app = wrap.OutsourcingProxy.PartnershipRequest(win.outsourcingCompanies.SelectedItem.ToString());

                if (app)
                {
                    MessageBox.Show("Approved!");
                    wrap.Proxy.AddPartnerCompany(wrap.Cvm.currentUser, win.outsourcingCompanies.SelectedItem.ToString());   //dodavanje u bazu

                    PartnerCompanies.Clear();  //ocisti bind listu 

                    //iscitaj iz baze i ubaci u listu
                    foreach (string comp in wrap.Proxy.GetAllPartnerCompanies(wrap.Cvm.currentUser))
                    {
                        if (!PartnerCompanies.Contains(comp))
                        {
                            PartnerCompanies.Add(comp);
                        }
                            
                        win.partnerCompaniesComboBox.Items.Refresh();
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

        private void ApproveProjectExecution(object param)
        {
            Context wrap = Context.GetInstance();
            AdminWindow win = wrap.Subwin as AdminWindow;

            if (win.partnerCompanies_Copy1.SelectedItem != null)
            {
                Project p = win.partnerCompanies_Copy1.SelectedItem as Project;

                p.State = States.approved;
                p.HiringCompany = wrap.Cvm.currentUser.Company;
                wrap.Proxy.UpdateProject(p);

                ActiveProjects.Add(p);         //dodaj u aktivne
                NotActiveProjects.Remove(p);   //obrisi iz neaktivnih
                Projects.Add(p);                //dodaj u sve projekte za tog konkretnoh CEO(kompaniju)

                win.projectsGrid.Items.Refresh();
            }
            
        }

        private void SendProjectExecution(object param)
        {
            Context wrap = Context.GetInstance();
            AdminWindow win = wrap.Subwin as AdminWindow;

            if (win.partnerCompanies_Copy.SelectedItem != null)
            {
                Project p = win.partnerCompanies_Copy.SelectedItem as Project;

                if (wrap.OutsourcingProxy.SendProject(p.Name, p.Description, p.HiringCompany))
                {
                    p.State = States.inProgress;
                    wrap.Proxy.UpdateProject(p);
                    ActiveProjects.Remove(p);
                }

                win.projectsGrid.Items.Refresh();
            }
        }

        public void ProveraPass(User currentUser)
        {
            Context wrap = Context.GetInstance();
            User newUser = wrap.Proxy.GetUser(currentUser.Username);

            while (true)
            {             
                DateTime userTime = Convert.ToDateTime(newUser.Passeditime);
                DateTime trenutnovr = DateTime.Now;

                TimeSpan span = trenutnovr.Subtract(userTime);

                if (span.Minutes > 2)
                {
                    ChangePassWindow changePass = new ChangePassWindow();
                    changePass.ShowDialog();
                    newUser = wrap.Proxy.GetUser(currentUser.Username);
                }
            }
        }

        public void CheckProjects(User currentUser)
        {

        }

        #endregion
    }
}

