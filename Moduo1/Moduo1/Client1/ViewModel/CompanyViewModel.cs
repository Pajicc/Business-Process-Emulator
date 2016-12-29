using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Client1.Command;

namespace Client1.ViewModel
{
    class CompanyViewModel: INotifyPropertyChanged
    {
        /// <summary>
        /// private instance
        /// </summary>
        private static CompanyViewModel model;

        /// <summary>
        /// rezult field
        /// </summary>
        private User user;

        /// <summary>
        /// currency field
        /// </summary>
        private List<User> usersList;

        /// <summary>
        /// Calc command
        /// </summary>
        public CompanyCommand serviceCommand { get; set; }

        /// <summary>
        /// private constructor
        /// </summary>
        private CompanyViewModel()
        {
            this.serviceCommand = new CompanyCommand();
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static CompanyViewModel Instance
        {
            get
            {
                if (model == null)
                    model = new CompanyViewModel();

                return model;
            }
        }

        #region UI Notification

        /// <summary>
        /// Event for notification of changes
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// OnPropertyChanged implementation for raising event PropertyChanged
        /// </summary>
        /// <param name="e">Contains name of property that changed</param>
        public void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, e);
            }
        }

        #endregion UI Notification

        public User User
        {
            get { return user; }
            set
            {
                this.user = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("User"));
            }
        }

        public List<User> UsersList
        {
            get { return usersList; }
            set
            {
                this.usersList = value;
                OnPropertyChanged(new System.ComponentModel.PropertyChangedEventArgs("UsersList"));
            }
        }
    }
}

