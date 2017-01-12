using Common;
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

            Context wrapper = Context.GetInstance();
            wrapper.Subwin = this;
            this.DataContext = wrapper.Cvm;

        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void DataGrid_DoubleMouseClick(object sender, MouseButtonEventArgs e)
        {
            Context wrap = Context.GetInstance();

            userStories.Items.Clear();

            foreach (string userStory in wrap.Proxy.GetAllUserStories(projectsGrid.SelectedItem as Project))
            {
                userStories.Items.Add(userStory);
            }
        }

    }
}
