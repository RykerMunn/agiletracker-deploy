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

namespace AgileTracker.View {
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window {
        int memberContribCount; // Used to differentiate between dynamic member textboxes

        public AddTaskWindow() {
            InitializeComponent();
            memberContribCount = 1;
        }

        private void onAddMemberClicked(object sender, RoutedEventArgs e) {
            if(memberContribCount < 15) {
                TextBox newNameBox = new TextBox();
                newNameBox.Name = $"tb_memberNameBox{memberContribCount}";
                newNameBox.Margin = new Thickness(0, 5, 0, 0);
                sp_memberList.Children.Add(newNameBox);
                //Increment to next textBox
                ++memberContribCount;
            }
        }
    }
}
