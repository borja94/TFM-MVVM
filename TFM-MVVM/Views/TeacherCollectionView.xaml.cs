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
    /// Interaction logic for TeacherCollectionView.xaml
    /// </summary>
    public partial class TeacherCollectionView : Page
    {

        public ObservableCollection<Teacher> teachersCollection { get; set; }
        private int teacherSelectedId;
        private readonly TeacherCollectionPresenter teacherCollectionPresenter;
        private ITeacherFormView _teacherFormView;

        public TeacherCollectionView()
        {
            teacherCollectionPresenter = new TeacherCollectionPresenter();
            teachersCollection = new ObservableCollection<Teacher>(teacherCollectionPresenter.getAllTeachers());

            DataContext = this;
            teacherSelectedId = -1;
            InitializeComponent();
        }






        private void removeTeacher(object sender, RoutedEventArgs e)
        {
            Teacher teacherAux = (Teacher)teacherCollectionList.SelectedItem;
            if (teacherAux != null)
            {
                teacherCollectionPresenter.removeTeacher(teacherAux.Id);
                teachersCollection.Remove(teacherAux);
            }
            clearForm();
        }

        private void editTeacher(object sender, RoutedEventArgs e)
        {
            _teacherFormView.editTeacherMode((Teacher)teacherCollectionList.SelectedItem);
        }

        private void newTeacher(object sender, RoutedEventArgs e)
        {
            clearForm();
        }

        private void clearForm()
        {
            _teacherFormView.newTeacherMode();
        }

        public void updateDataTable()
        {
            teachersCollection.Clear();
            foreach (Teacher item in teacherCollectionPresenter.getAllTeachers())
            {
                teachersCollection.Add(item);
            }
        }

        public void setTeacherFormView(ITeacherFormView teacherFormView)
        {
            _teacherFormView = teacherFormView;
        }

    }
}
