using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using TFM_MVVM.Models;
using TFM_MVVM.Presenters;

namespace TFM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for TeacherView.xaml
    /// </summary>
    public partial class TeacherView : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<Subject> subjectsCollection { get; set; }
        public ObservableCollection<Teacher> teachersCollection { get; set; }
        public ObservableCollection<Subject> assignedSubjectsCollection { get; set; }
        private string _teacherName;
        private int teacherSelectedId;
        private TeacherPresenter teacherPresenter;

        public string TeacherName
        {
            get { return _teacherName; }
            set
            {
                if (value != _teacherName)
                {
                    _teacherName = value;
                    this.OnPropertyChanged("TeacherName");
                }
            }
        }
        private string _teacherSurname;

        public string TeacherSurName
        {
            get { return _teacherSurname; }
            set
            {
                if (value != _teacherSurname)
                {
                    _teacherSurname = value;
                    OnPropertyChanged("TeacherSurName");
                }
            }
        }

        public TeacherView()
        {
            teacherPresenter = new TeacherPresenter();
            assignedSubjectsCollection = new ObservableCollection<Subject>();
            subjectsCollection = new ObservableCollection<Subject>(teacherPresenter.GetAllSubjects());
            teachersCollection = new ObservableCollection<Teacher>(teacherPresenter.getAllTeachers());
            InitializeComponent();
            DataContext = this;
            teacherSelectedId = -1;
        }

        private void returnMenuView(object sender, RoutedEventArgs e)
        {
            Menu menuView = new Menu();
            this.NavigationService.Navigate(menuView);

        }

        private void addSubject(object sender, RoutedEventArgs e)
        {
            if (subjectsListBox.SelectedItem != null)
            {
                Subject element = (Subject)subjectsListBox.SelectedItem;
                subjectsCollection.Remove(element);
                assignedSubjectsCollection.Add(element);
            }
        }

        private void removeSubject(object sender, RoutedEventArgs e)
        {
            if (assignedSubjectsListBox.SelectedItem != null)
            {
                Subject element = (Subject)assignedSubjectsListBox.SelectedItem;
                assignedSubjectsCollection.Remove(element);
                subjectsCollection.Add(element);
            }
        }

        private void saveTeacher(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TeacherName) && !string.IsNullOrWhiteSpace(TeacherSurName))
            {
                Teacher teacherAux = new Teacher()
                {
                    Id = teacherSelectedId,
                    Name = TeacherName,
                    Surname = TeacherSurName,
                    Subjects = new List<Subject>(assignedSubjectsCollection)
                };
                if (teacherAux.Id == -1)
                    teacherPresenter.insertNewTeacher(teacherAux);
                else
                    teacherPresenter.updateNewTeacher(teacherAux);

                teachersCollection.Clear();
                foreach (Teacher item in teacherPresenter.getAllTeachers())
                {
                    teachersCollection.Add(item);
                }
                clearForm();
            }
        }

        private void removeTeacher(object sender, RoutedEventArgs e)
        {
            Teacher teacherAux = (Teacher)teacherCollectionList.SelectedItem;
            if (teacherAux != null)
            {
                teacherPresenter.removeTeacher(teacherAux.Id);
                teachersCollection.Remove(teacherAux);
            }
            clearForm();
        }

        private void editTeacher(object sender, RoutedEventArgs e)
        {
            Teacher teacherAux = (Teacher)teacherCollectionList.SelectedItem;
            if (teacherAux != null)
            {
                TeacherName = teacherAux.Name;
                TeacherSurName = teacherAux.Surname;
                teacherSelectedId = teacherAux.Id;
                foreach (Subject subject in teacherAux.Subjects)
                {
                    if (subjectsCollection.Remove(subject))
                    {
                        assignedSubjectsCollection.Add(subject);
                    }
                }
            }
        }

        private void newTeacher(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            TeacherName = string.Empty;
            TeacherSurName = string.Empty;
            teacherSelectedId = -1;
            Subject[] assignedSubjectsCollectionAux = new List<Subject>(assignedSubjectsCollection).ToArray();
            for (int i = assignedSubjectsCollection.Count - 1; i >= 0; i--)
            {
                Subject subject = assignedSubjectsCollectionAux[i];
                assignedSubjectsCollection.Remove(subject);
                subjectsCollection.Add(subject);
            }
        }


        protected void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
