using System;
using System.Collections.Generic;
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
using TFM_MVVM.Presenters;

namespace TFM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class MainView : Page, INotifyPropertyChanged
    {
        private string _numStudents;
        private string _numTeachers;
        private string _numSubjects;
        private readonly MainPresenter _mainPresenter;

        public string NumStudents
        {
            get { return _numStudents; }
            set
            {
                if (value != _numStudents)
                {
                    _numStudents = value;
                    this.OnPropertyChanged("NumStudents");
                }
            }
        }

        public string NumTeachers
        {
            get { return _numTeachers; }
            set
            {
                if (value != _numTeachers)
                {
                    _numTeachers = value;
                    this.OnPropertyChanged("NumTeachers");
                }
            }
        }

        public string NumSubjects
        {
            get { return _numSubjects; }
            set
            {
                if (value != _numSubjects)
                {
                    _numSubjects = value;
                    this.OnPropertyChanged("NumSubjects");
                }
            }
        }

        public MainView()
        {
            _mainPresenter = new MainPresenter();
            NumStudents = "Nº de alumnos:" + _mainPresenter.GetNumStudents();
            NumTeachers = "Nº de profesores:" + _mainPresenter.GetNumTeachers();
            NumSubjects = "Nº de asignaturas:" + _mainPresenter.GetNumSubjects();
            DataContext = this;
            InitializeComponent();

        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void TeacherNavigate(object sender, RoutedEventArgs e)
        {
            TeacherView teacherView = new TeacherView();
            this.NavigationService.Navigate(teacherView);
        }

        private void SubjectNavigate(object sender, RoutedEventArgs e)
        {
            SubjectView subjectView = new SubjectView();
            this.NavigationService.Navigate(subjectView);
        }


        private void StudentNavigate(object sender, RoutedEventArgs e)
        {
            StudentView studentView = new StudentView();
            this.NavigationService.Navigate(studentView);
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
