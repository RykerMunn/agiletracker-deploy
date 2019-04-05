using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileTracker {
    public class Member : INotifyPropertyChanged {
        public Member(string user, string pass, string projID = "N/A") {
            Username = user;
            Password = pass;
            ProjectID = projID;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        private string _username;
        public string Username {
            get { return _username; }
            set {
                if (value.Length > 0) _username = value;
                else throw new Exception("Usernames cannot be empty.");
            } }
        private string _password;
        public string Password {
            get { return _password; }
            set {
                if (value.Length > 5) _password = value;
                else throw new Exception("Passwords must be minimum 6 characters.");
            }
        }
        private string _projectID;
        public string ProjectID {
            get { return _projectID; }
            set {
                if (value.Length > 0) _projectID = value;
                else throw new Exception("ProjectID cannot be empty.");
            }
        }
        
        public override string ToString() {
            return $"{Username}";
        }
    }
}
