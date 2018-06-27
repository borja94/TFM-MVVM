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
    /// Interaction logic for StudentCollectionView.xaml
    /// </summary>
    public partial class StudentCollectionView : Page
    {

        public ObservableCollection<Student> studentsCollection { get; set; }
        private int studentSelectedId;
        private readonly StudentCollectionPresenter studentCollectionPresenter;
        private IStudentFormView _studentFormView;

        public StudentCollectionView()
        {
            studentCollectionPresenter = new StudentCollectionPresenter();
            studentsCollection = new ObservableCollection<Student>(studentCollectionPresenter.getAllStudents());

            DataContext = this;
            studentSelectedId = -1;
            InitializeComponent();
        }






        private void removeStudent(object sender, RoutedEventArgs e)
        {
            Student studentAux = (Student)studentCollectionList.SelectedItem;
            if (studentAux != null)
            {
                studentCollectionPresenter.removeStudent(studentAux.Id);
                studentsCollection.Remove(studentAux);
            }
            clearForm();
        }

        private void editStudent(object sender, RoutedEventArgs e)
        {
            _studentFormView.editStudentMode((Student)studentCollectionList.SelectedItem);
        }

        private void newStudent(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            _studentFormView.newStudentMode();
        }

        public void updateDataTable()
        {
            studentsCollection.Clear();
            foreach (Student item in studentCollectionPresenter.getAllStudents())
            {
                studentsCollection.Add(item);
            }
        }

        public void setStudentFormView(IStudentFormView studentFormView)
        {
            _studentFormView = studentFormView;
        }

    }
}
