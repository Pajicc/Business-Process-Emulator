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

namespace Client2
{
    /// <summary>
    /// Interaction logic for PromenaLozinke.xaml
    /// </summary>
    public partial class PromenaLozinke : Window
    {
        public User user = new User();

        public PromenaLozinke(User u)
        {
            InitializeComponent();

            user = u;
            tb1.Text=u.Username;
            tb1.IsReadOnly= true;

            tb2.Text = u.Password;
            tb2.IsReadOnly = true;

            


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow.proxy.UpdatePass(user.Username, tb3.Text.ToString());
            this.Close();
        }

    }
}
