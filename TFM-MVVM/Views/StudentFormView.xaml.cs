using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using TFM_MVVM.Models;
using TFM_MVVM.Presenters;

namespace TFM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for StudentFormView.xaml
    /// </summary>
    public partial class StudentFormView : Page, INotifyPropertyChanged, IStudentFormView
    {

        public ObservableCollection<Subject> subjectsCollection { get; set; }
        public ObservableCollection<Subject> assignedSubjectsCollection { get; set; }
        private readonly StudentFormPresenter studentPresenter;
        private StudentCollectionView _studentCollectionView;

        private int studentSelectedId;
        private string _studentName;
        public string StudentName
        {
            get { return _studentName; }
            set
            {
                if (value != _studentName)
                {
                    _studentName = value;
                    this.OnPropertyChanged("StudentName");
                }
            }
        }
        private string _studentSurname;

        public string StudentSurName
        {
            get { return _studentSurname; }
            set
            {
                if (value != _studentSurname)
                {
                    _studentSurname = value;
                    OnPropertyChanged("StudentSurName");
                }
            }
        }


        public StudentFormView()
        {
            studentPresenter = new StudentFormPresenter();
            studentSelectedId = -1;
            assignedSubjectsCollection = new ObservableCollection<Subject>();
            subjectsCollection = new ObservableCollection<Subject>(studentPresenter.GetAllSubjects());
            DataContext = this;

            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

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
                Student studentAux = new Student()
                {
                    Id = studentSelectedId,
                    Name = StudentName,
                    Surname = StudentSurName,
                    Subjects = new List<Subject>(assignedSubjectsCollection)
                };
                if (studentAux.Id == -1)
                    studentPresenter.insertNewStudent(studentAux);
                else
                    studentPresenter.updateNewStudent(studentAux);

                _studentCollectionView.updateDataTable();

                clearForm();
            }
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

        public void editStudentMode(Student student)
        {
            if (student != null)
            {
                StudentName = student.Name;
                StudentSurName = student.Surname;
                studentSelectedId = student.Id;
                foreach (Subject subject in student.Subjects)
                {
                    if (subjectsCollection.Remove(subject))
                    {
                        assignedSubjectsCollection.Add(subject);
                    }
                }
            }
        }

        public void newStudentMode()
        {
            clearForm();
        }

        public void setStudentCollectionView(StudentCollectionView studentCollectionView)
        {
            _studentCollectionView = studentCollectionView;
        }
    }
}
