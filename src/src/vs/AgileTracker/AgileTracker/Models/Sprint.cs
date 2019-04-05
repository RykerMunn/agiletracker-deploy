using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AgileTracker.Models {
   public class Sprint : INotifyPropertyChanged {
        public Sprint(int sNum) {
            SprintNumber = sNum;
            TaskList = new List<Task>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //Class Members
        private int _sprintNum;
        public int SprintNumber { get { return _sprintNum; } set { _sprintNum = value; RaisePropertyChanged("SprintNumber"); } }

        private List<Task> _taskList;        
        public List<Task> TaskList { get { return _taskList; } set { _taskList = value; RaisePropertyChanged("TaskList"); } }

        private int _numTasks;
        public int NumberOfTasks { get { return TaskList.Count(); } set { _numTasks = value; RaisePropertyChanged("NumberOfTasks"); } }
    }
}
