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

namespace Client1
{
    /// <summary>
    /// Interaction logic for ScrumMasterWindow.xaml
    /// </summary>
    public partial class ScrumMasterWindow : Window
    {
        public ScrumMasterWindow()
        {
            InitializeComponent();

            Context wrapper = Context.getInstance();
            wrapper.subwin = this;
            this.DataContext = wrapper.cvm;

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

            //wrap.proxy.GetAllStories(projectsGrid.SelectedItem as Project);

            //userStories.Items.Add("User story 1");

        }

    }
}
