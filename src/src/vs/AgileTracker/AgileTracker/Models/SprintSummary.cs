using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

/*
 * /Brief:      Will contain all the information needed to populate the dataGrid inside the sprint summary
 * /Author:     Thomas Woods
 * /Date:       2019-03-17
 * */
namespace AgileTracker.Models{
    public class SprintSummary : INotifyPropertyChanged{
        public SprintSummary(string projName, string task, bool compeleted, double time ){
            Tasks = task;
            CompletedTask = compeleted;
            Time = time;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //Class Members
        private bool _completedTask;
        public bool CompletedTask{
            get { return _completedTask; }
            set
            {
               _completedTask = value;
             
            }
        }
        private double _time;
        public double Time
        {
            get { return _time; }
            set { _time = value; }
        }
        private string _tasks;
        public string Tasks
        {
            get { return _tasks; }
            set { _tasks = value; }
        }
        
    }
}
