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
    /// Interaction logic for SubjectView.xaml
    /// </summary>
    public partial class SubjectView : Page, INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<Subject> subjectsCollection { get; set; }

        private string _subjectName;
        private int subjectSelectedId;
        private SubjectPresenter subjectPresenter;

        public string SubjectTitle
        {
            get { return _subjectName; }
            set
            {
                if (value != _subjectName)
                {
                    _subjectName = value;
                    this.OnPropertyChanged("SubjectTitle");
                }
            }
        }
        private int? _subjectCourse;

        public int? SubjectCourse
        {
            get { return _subjectCourse; }
            set
            {
                if (value != _subjectCourse)
                {
                    _subjectCourse = value;
                    OnPropertyChanged("SubjectCourse");
                }
            }
        }

        public SubjectView()
        {
            subjectSelectedId = -1;
            subjectPresenter = new SubjectPresenter();
            subjectsCollection = new ObservableCollection<Subject>(subjectPresenter.getAllSubjects());

            InitializeComponent();
            DataContext = this;
        }

        private void returnMenuView(object sender, RoutedEventArgs e)
        {
            Menu menuView = new Menu();
            this.NavigationService.Navigate(menuView);

        }

        private void saveSubject(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SubjectTitle) && SubjectCourse.HasValue)
            {
                Subject subjectAux = new Subject()
                {
                    Id = subjectSelectedId,
                    Title = SubjectTitle,
                    Course = SubjectCourse.Value,
                };

                if (subjectAux.Id != -1)
                    subjectPresenter.updateNewSubject(subjectAux);
                else
                    subjectPresenter.insertNewSubject(subjectAux);

                subjectsCollection.Clear();
                foreach (Subject item in subjectPresenter.getAllSubjects())
                {
                    subjectsCollection.Add(item);
                }
            }
        }

        private void removeSubject(object sender, RoutedEventArgs e)
        {
            Subject subjectAux = (Subject)subjectCollectionList.SelectedItem;
            if (subjectAux != null)
            {
                subjectPresenter.removeSubject(subjectAux.Id);
                subjectsCollection.Remove(subjectAux);
            }
            clearForm();
        }

        private void editSubject(object sender, RoutedEventArgs e)
        {
            Subject subjectAux = (Subject)subjectCollectionList.SelectedItem;
            if (subjectAux != null)
            {
                SubjectTitle = subjectAux.Title;
                SubjectCourse = subjectAux.Course;
                subjectSelectedId = subjectAux.Id;
            }
        }

        private void newSubject(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            SubjectTitle = string.Empty;
            SubjectCourse = null;
            subjectSelectedId = -1;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
