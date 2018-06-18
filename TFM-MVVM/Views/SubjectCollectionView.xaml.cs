using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for SubjectCollectionView.xaml
    /// </summary>
    public partial class SubjectCollectionView : Page
    {

        public ObservableCollection<Subject> subjectsCollection { get; set; }
        private int subjectSelectedId;
        private readonly SubjectCollectionPresenter subjectCollectionPresenter;
        private ISubjectFormView _subjectFormView;

        public SubjectCollectionView()
        {
            subjectCollectionPresenter = new SubjectCollectionPresenter();
            subjectsCollection = new ObservableCollection<Subject>(subjectCollectionPresenter.getAllSubjects());

            DataContext = this;
            subjectSelectedId = -1;
            InitializeComponent();
        }






        private void removeSubject(object sender, RoutedEventArgs e)
        {
            Subject subjectAux = (Subject)subjectCollectionList.SelectedItem;
            if (subjectAux != null)
            {
                subjectCollectionPresenter.removeSubject(subjectAux.Id);
                subjectsCollection.Remove(subjectAux);
            }
            clearForm();
        }

        private void editSubject(object sender, RoutedEventArgs e)
        {
            _subjectFormView.editSubjectMode((Subject)subjectCollectionList.SelectedItem);
        }

        private void newSubject(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            _subjectFormView.newSubjectMode();
        }

        public void updateDataTable()
        {
            subjectsCollection.Clear();
            foreach (Subject item in subjectCollectionPresenter.getAllSubjects())
            {
                subjectsCollection.Add(item);
            }
        }

        public void setSubjectFormView(ISubjectFormView subjectFormView)
        {
            _subjectFormView = subjectFormView;
        }

    }
}
