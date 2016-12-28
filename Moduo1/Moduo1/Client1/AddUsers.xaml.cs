using System.Windows;
using Common;

namespace Client1
{
    /// <summary>
    /// Interaction logic for AddUsers.xaml
    /// </summary>
    public partial class AddUsers : Window
    {
        public AddUsers()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User u = new User();
            
            u.Username = textbox1.Text;       //Dodavanje usera - za punjenje baze
            u.Password = textbox2.Password;

            MainWindow.proxy.AddUser(u);
        }
    }
}
