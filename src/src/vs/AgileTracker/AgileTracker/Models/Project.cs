using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AgileTracker.Models {
    public class Project : INotifyPropertyChanged {        
        public Project(string projName, string username, string userID) {
            ProjectName = projName;
            Username = username;
            UserID = userID;
            Sprints = new List<Sprint>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //Class Members
        private string _projectName;
        public string ProjectName {
            get { return _projectName; }
            set {
                if (value.Length > 0) {
                    _projectName = value;
                    RaisePropertyChanged("ProjectName");
                } else throw new Exception("Project name cannot be empty.");
            }
        }
        private string _username;
        public string Username {
            get { return _username; }
            set {
                if (value.Length > 0) {
                    _username = value;
                    RaisePropertyChanged("Username");
                } else throw new Exception("Project creator cannot be empty.");
            }
        }
        private string _userID;
        public string UserID {
            get { return _userID; }
            set {
                if (value.Length > 0) {
                    _userID = value;
                    RaisePropertyChanged("UserID");
                } else throw new Exception("Creator UserID cannot be empty.");
            }
        }
        private List<Sprint> _sprints;
        public List<Sprint> Sprints {
            get { return _sprints; }
            set { _sprints = value; RaisePropertyChanged("Sprints"); }
        }
    }
}
