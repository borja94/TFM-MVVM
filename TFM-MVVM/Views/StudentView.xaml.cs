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
    /// Interaction logic for StudentView.xaml
    /// </summary>
    public partial class StudentView : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<Subject> subjectsCollection { get; set; }
        public ObservableCollection<Student> studentsCollection { get; set; }
        public ObservableCollection<Subject> assignedSubjectsCollection { get; set; }
        private string _teacherName;
        private int studentSelectedId;
        private StudentPresenter studentPresenter;

        public string StudentName
        {
            get { return _teacherName; }
            set
            {
                if (value != _teacherName)
                {
                    _teacherName = value;
                    this.OnPropertyChanged("StudentName");
                }
            }
        }
        private string _teacherSurname;

        public string StudentSurName
        {
            get { return _teacherSurname; }
            set
            {
                if (value != _teacherSurname)
                {
                    _teacherSurname = value;
                    OnPropertyChanged("StudentSurName");
                }
            }
        }

        public StudentView()
        {
            studentPresenter = new StudentPresenter();
            assignedSubjectsCollection = new ObservableCollection<Subject>();
            subjectsCollection = new ObservableCollection<Subject>(studentPresenter.GetAllSubjects());
            studentsCollection = new ObservableCollection<Student>(studentPresenter.getAllStudents());
            InitializeComponent();
            DataContext = this;
            studentSelectedId = -1;
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

        private void saveStudent(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(StudentName) && !string.IsNullOrWhiteSpace(StudentSurName))
            {
                Student teacherAux = new Student()
                {
                    Id = studentSelectedId,
                    Name = StudentName,
                    Surname = StudentSurName,
                    Subject = new List<Subject>(assignedSubjectsCollection)
                };
                if (teacherAux.Id == -1)
                    studentPresenter.insertNewStudent(teacherAux);
                else
                    studentPresenter.updateNewStudent(teacherAux);

                studentsCollection.Clear();
                foreach (Student item in studentPresenter.getAllStudents())
                {
                    studentsCollection.Add(item);
                }
                clearForm();
            }
        }

        private void removeStudent(object sender, RoutedEventArgs e)
        {
            Student teacherAux = (Student)studentCollectionList.SelectedItem;
            if (teacherAux != null)
            {
                studentPresenter.removeStudent(teacherAux.Id);
                studentsCollection.Remove(teacherAux);
            }
            clearForm();
        }

        private void editStudent(object sender, RoutedEventArgs e)
        {
            Student teacherAux = (Student)studentCollectionList.SelectedItem;
            if (teacherAux != null)
            {
                StudentName = teacherAux.Name;
                StudentSurName = teacherAux.Surname;
                studentSelectedId = teacherAux.Id;
                foreach (Subject subject in teacherAux.Subject)
                {
                    if (subjectsCollection.Remove(subject))
                    {
                        assignedSubjectsCollection.Add(subject);
                    }
                }
            }
        }

        private void newStudent(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            StudentName = string.Empty;
            StudentSurName = string.Empty;
            studentSelectedId = -1;
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
