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
    /// Interaction logic for ViewSelectedProjectWindow.xaml
    /// </summary>
    public partial class ViewSelectedProjectWindow : Window {
        private ViewModelMain vm;
        public ViewSelectedProjectWindow() {
            InitializeComponent();
            vm = MainWindow.vm;
            this.DataContext = vm;
            
        }
    }
}
