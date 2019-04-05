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
using AgileTracker.Controller;

namespace AgileTracker.View {
    /// <summary>
    /// Interaction logic for AddNewSprintWindow.xaml
    /// </summary>
    public partial class AddNewSprintWindow : Window {
        ViewModelMain vm;
        public AddNewSprintWindow() {
            InitializeComponent();
            vm = MainWindow.vm;
            this.DataContext = vm;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            vm.NewSprintName = null;
        }
    }
}
