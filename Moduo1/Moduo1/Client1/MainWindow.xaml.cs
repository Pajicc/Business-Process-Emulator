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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ServiceModel;
using Common;

namespace Client1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public static Client1Proxy proxy;

        public MainWindow()
        {
            InitializeComponent();

            Context wrapper = Context.getInstance();
            wrapper.mw = this;
            this.DataContext = wrapper.cvm;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Context wrapper = Context.getInstance();
            AddUsers win = new AddUsers();
            wrapper.subwin = win;
            win.DataContext = wrapper.cvm;
            win.ShowDialog();
        }
    }
}
