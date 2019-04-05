using AgileTracker.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace AgileTracker.View
{
    /// <summary>
    /// Interaction logic for SprintSummaryWindow.xaml
    /// </summary>
    public partial class SprintSummaryWindow : Window
    {

        ObservableCollection<SprintSummary> sprintSummary {get; set;}
        public SprintSummaryWindow()
        {
            InitializeComponent();
            sprintSummary = new ObservableCollection<SprintSummary>();
            sprintSummary.Add(new SprintSummary("Project Name", "This is very long and will be the task information section", false, 35));

            dgSprintInfo.DataContext = sprintSummary;

        }

        // constructor to get all the data or get the data in this window so it's fresh
        public SprintSummaryWindow(string projectName, List<Task> tasks)
        {
            InitializeComponent();
            sprintSummary = new ObservableCollection<SprintSummary>();
            sprintSummary.Add(new SprintSummary("Project Name", "This is very long and will be the task information section", false, 35));

            dgSprintInfo.ItemsSource = sprintSummary;

        }
    }
}
