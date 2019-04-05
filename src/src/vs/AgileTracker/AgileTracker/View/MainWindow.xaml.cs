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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public static ViewModelMain vm;
        public MainWindow() {
            InitializeComponent();
            Application.Current.MainWindow = this;

            vm = new ViewModelMain();
            this.DataContext = vm;
        }        

        private void onViewMemberClicked(object sender, RoutedEventArgs e) {
            
        }

        private void onWindowClosing(object sender, System.ComponentModel.CancelEventArgs e) {            
        }

        private void onViewSprintSummaryClick(object sender, RoutedEventArgs e)
        {
            // need to pass in the data from somewhere to get the tasks and the project information or get it inside this class
            SprintSummaryWindow sprintSummaryWindow = new SprintSummaryWindow();
            sprintSummaryWindow.ShowDialog();
        }
    }
}
