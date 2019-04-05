using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace AgileTracker {
    public class Task : INotifyPropertyChanged {
        //Task Enum
        public enum TaskDescriptors { Not_Started, In_Progress, Finished };

        public Task() {
            Members = new List<Member>();
        }
        public Task(string tID, string uID, string user, TaskDescriptors state, double est, double act, string dt) {
            TaskID = tID;
            UserID = uID;
            Username = user;
            Members = new List<Member>();
            State = state;
            EstimatedTime = est;
            ActualTime = act;
            Details = dt;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        //Class Properties
        private string _taskID;
        public string TaskID {
            get { return _taskID; }
            set {
                if (value.Length > 0) _taskID = value;
                else throw new Exception("TaskID cannot be empty.");
            }
        }
        private string _userID;
        public string UserID {
            get { return _userID; }
            set {
                if (value.Length > 0) _userID = value;
                else throw new Exception("UserID cannot be empty.");
            }
        }
        private string _username;
        public string Username {
            get { return _username; }
            set { if (value.Length > 0) _username = value;
                else throw new Exception("Username cannot be empty.");
            }
        }
        private List<Member> _members;
        public List<Member> Members {
            get { return _members; }
            set { _members = value; }
        }
        private TaskDescriptors _state;
        public TaskDescriptors State {
            get { return _state; }
            set { _state = value; }
        }        
        private double _estTime;
        public double EstimatedTime {
            get { return _estTime; }
            set {
                if (value > 0) _estTime = value;
                else throw new Exception("Estimated time cannot be a negative value.");
            }
        }
        private double _actTime;
        public double ActualTime {
            get { return _actTime; }
            set {
                if (value > 0) _actTime = value;
                else throw new Exception("Actual time cannot be a negative value.");
            }
        }
        private string _details;
        public string Details {
            get { return _details; }
            set { _details = value; }
        }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"-- Task Summary --");
            sb.AppendLine($"Created By: [{Username} - {UserID}]");
            sb.AppendLine($"Status: {State}");
            sb.AppendLine($"Estimated Time: {EstimatedTime} -- Actual Time: {ActualTime}");
            sb.AppendLine($"---");
            sb.Append($"Members: ");
            foreach (Member mem in Members) sb.Append($"[{mem.ToString()}] ");
            sb.AppendLine($"\n---");
            sb.AppendLine($"Details: {Details.ToString()}");
            return sb.ToString();
        }
    }
}
