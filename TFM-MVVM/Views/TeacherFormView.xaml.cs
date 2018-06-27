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
    /// Interaction logic for TeacherFormView.xaml
    /// </summary>
    public partial class TeacherFormView : Page, INotifyPropertyChanged, ITeacherFormView
    {

        public ObservableCollection<Subject> subjectsCollection { get; set; }
        public ObservableCollection<Subject> assignedSubjectsCollection { get; set; }
        private readonly TeacherFormPresenter teacherPresenter;
        private TeacherCollectionView _teacherCollectionView;

        private int teacherSelectedId;
        private string _teacherName;
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


        public TeacherFormView()
        {
            teacherPresenter = new TeacherFormPresenter();
            teacherSelectedId = -1;
            assignedSubjectsCollection = new ObservableCollection<Subject>();
            subjectsCollection = new ObservableCollection<Subject>(teacherPresenter.GetAllSubjects());
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

                _teacherCollectionView.updateDataTable();

                clearForm();
            }
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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void editTeacherMode(Teacher teacher)
        {
            if (teacher != null)
            {
                TeacherName = teacher.Name;
                TeacherSurName = teacher.Surname;
                teacherSelectedId = teacher.Id;
                foreach (Subject subject in teacher.Subjects)
                {
                    if (subjectsCollection.Remove(subject))
                    {
                        assignedSubjectsCollection.Add(subject);
                    }
                }
            }
        }

        public void newTeacherMode()
        {
            clearForm();
        }

        public void setTeacherCollectionView(TeacherCollectionView teacherCollectionView)
        {
            _teacherCollectionView = teacherCollectionView;
        }
    }
}
