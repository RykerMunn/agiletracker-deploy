using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AgileTracker.Models;
using AgileTracker.View;
using AgileTracker.Helpers;

namespace AgileTracker.Controller {
    public class ViewModelMain : DependencyObject {
        #region PropertyChanged Event Handler
        public event PropertyChangedEventHandler PropertyChanged;
        void RaisePropertyChanged(string prop) {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
        #endregion

        //Constructor
        public ViewModelMain() {
            ProjDGCollection = new ObservableCollection<Project>(); //{ new Project("ye","no","1"), new Project("ye", "no", "1") };
            SprintDGCollection = new ObservableCollection<Sprint>() { new Sprint(1), new Sprint(2) };

            //Initialize the relaycommands
            OpenAllProjectsWindowCommand = new RelayCommand(OpenAllProjectsWindowImp);
            OpenAddNewProjectWindowCommand = new RelayCommand(OpenAddNewProjectWindowImp);
            AddNewProjectCommand = new RelayCommand(AddNewProjectImp);
            RemoveSelectedProjectCommand = new RelayCommand(RemoveSelectedProjectImp);
            ClearNewProjectNameCommand = new RelayCommand(ClearNewProjectNameImp);
            OpenViewSelectedProjectWindowCommand = new RelayCommand(OpenViewSelectedProjectWindowImp);
            AddNewSprintCommand = new RelayCommand(AddNewSprintImp);
            RemoveSelectedSprintCommand = new RelayCommand(RemoveSelectedSprintImp);
        }

        #region Window Declarations
        ViewProjectsWindow viewProjectsWindow = null;
        AddNewProjectWindow addNewProjectWindow = null;
        ViewSelectedProjectWindow viewSelectedProjectWindow = null;
        #endregion

        #region Observable Collections
        //Observable Collections
        //--ViewProjectsWindow DataGrid Collections        
        public ObservableCollection<Project> ProjDGCollection {
            get { return (ObservableCollection<Project>)GetValue(projDGCollectionProperty); }
            set { SetValue(projDGCollectionProperty, value); }
        }
        public static readonly DependencyProperty projDGCollectionProperty =
            DependencyProperty.Register("projDGCollection", typeof(ObservableCollection<Project>),
                typeof(ViewModelMain), new PropertyMetadata(null));

        public ObservableCollection<Sprint> SprintDGCollection {
            get { return (ObservableCollection<Sprint>)GetValue(sprintDGCollectionProperty); }
            set { SetValue(sprintDGCollectionProperty, value); }
        }
        public static readonly DependencyProperty sprintDGCollectionProperty =
            DependencyProperty.Register("sprintDGCollection", typeof(ObservableCollection<Sprint>),
                typeof(ViewModelMain), new PropertyMetadata());

        public Project SelectedProject {
            get { return (Project)GetValue(SelectedProjectProperty); }
            set { SetValue(SelectedProjectProperty, value); }
        }        
        public static readonly DependencyProperty SelectedProjectProperty =
            DependencyProperty.Register("SelectedProject", typeof(Project), typeof(ViewModelMain), new PropertyMetadata(null));

        public Sprint SelectedSprint {
            get { return (Sprint)GetValue(SelectedSprintProperty); }
            set { SetValue(SelectedSprintProperty, value); }
        }       
        public static readonly DependencyProperty SelectedSprintProperty =
            DependencyProperty.Register("SelectedSprint", typeof(Sprint), typeof(ViewModelMain), new PropertyMetadata(null));



        #endregion

        #region DependencyProperty Variables
        private string _newProjectName;
        public string NewProjectName { get { return _newProjectName; } set { _newProjectName = value; RaisePropertyChanged("NewProjectName"); } }
        private string _newSprintName;
        public string NewSprintName { get { return _newSprintName; } set { _newSprintName = value; RaisePropertyChanged("NewSprintName"); } }
        #endregion

        #region RelayCommands Declarations
        public RelayCommand OpenAllProjectsWindowCommand { get; set; }
        public RelayCommand OpenAddNewProjectWindowCommand { get; set; }
        public RelayCommand AddNewProjectCommand { get; set; }        
        public RelayCommand RemoveSelectedProjectCommand { get; set; }
        public RelayCommand ClearNewProjectNameCommand { get; set; }
        public RelayCommand OpenViewSelectedProjectWindowCommand { get; set; }
        public RelayCommand AddNewSprintCommand { get; set; }
        public RelayCommand RemoveSelectedSprintCommand { get; set; }

        #endregion

        #region RelayCommands Implementations
        private void OpenAllProjectsWindowImp(object obj) {
            try {
                viewProjectsWindow = new ViewProjectsWindow();
                viewProjectsWindow.ShowDialog();                
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }            
        }

        private void OpenAddNewProjectWindowImp(object obj) {
            try {
                addNewProjectWindow = new AddNewProjectWindow();
                addNewProjectWindow.ShowDialog();
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddNewProjectImp(object obj) {
            try {
                if (NewProjectName.Equals(""))
                    throw new Exception("A project name is required.");
                foreach (Project proj in ProjDGCollection) {
                    if (proj.ProjectName.Equals(NewProjectName))                                            
                        throw new Exception("A project already exists with that name.");
                }
                ProjDGCollection.Add(new Project(NewProjectName, "test", "test"));
                addNewProjectWindow.Close();
                MessageBox.Show("Project successfully created!", "Project Created", MessageBoxButton.OK);                
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveSelectedProjectImp(object obj) {
            try {
                ProjDGCollection.Remove(SelectedProject);
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ClearNewProjectNameImp(object obj) {
            try {
                NewProjectName = "";
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OpenViewSelectedProjectWindowImp(object obj) {
            try {
                viewSelectedProjectWindow = new ViewSelectedProjectWindow();
                //SprintDGCollection = new ObservableCollection<Sprint>(SelectedProject.Sprints);
                viewSelectedProjectWindow.ShowDialog();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddNewSprintImp(object obj) {
            try {
                SprintDGCollection.Add(new Sprint(SprintDGCollection.Count() + 1));
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RemoveSelectedSprintImp(object obj) {
            try {
                SprintDGCollection.Remove(SelectedSprint);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        #endregion
    }
}
