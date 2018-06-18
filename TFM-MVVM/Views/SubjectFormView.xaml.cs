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
    /// Interaction logic for SubjectFormView.xaml
    /// </summary>
    public partial class SubjectFormView : Page, INotifyPropertyChanged, ISubjectFormView
    {

        private readonly SubjectFormPresenter subjectPresenter;
        private SubjectCollectionView _subjectCollectionView;

        private int subjectSelectedId;
        private string _subjectTitle;
        public string SubjectTitle
        {
            get { return _subjectTitle; }
            set
            {
                if (value != _subjectTitle)
                {
                    _subjectTitle = value;
                    this.OnPropertyChanged("SubjectTitle");
                }
            }
        }
        private int? _course;

        public int? Course
        {
            get { return _course; }
            set
            {
                if (value != _course)
                {
                    _course = value;
                    OnPropertyChanged("Course");
                }
            }
        }


        public SubjectFormView()
        {
            subjectPresenter = new SubjectFormPresenter();
            subjectSelectedId = -1;

            DataContext = this;

            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;



        private void saveSubject(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(SubjectTitle) && Course.HasValue)
            {
                Subject subjectAux = new Subject()
                {
                    Id = subjectSelectedId,
                    Title = SubjectTitle,
                    Course = Course.Value
                };
                if (subjectAux.Id == -1)
                    subjectPresenter.insertNewSubject(subjectAux);
                else
                    subjectPresenter.updateNewSubject(subjectAux);

                _subjectCollectionView.updateDataTable();

                clearForm();
            }
        }

        private void clearForm()
        {
            SubjectTitle = string.Empty;
            Course = null;
            subjectSelectedId = -1;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void editSubjectMode(Subject subject)
        {
            if (subject != null)
            {
                SubjectTitle = subject.Title;
                Course = subject.Course;
                subjectSelectedId = subject.Id;
            }
        }

        public void newSubjectMode()
        {
            clearForm();
        }

        public void setSubjectCollectionView(SubjectCollectionView subjectCollectionView)
        {
            _subjectCollectionView = subjectCollectionView;
        }
    }
}
