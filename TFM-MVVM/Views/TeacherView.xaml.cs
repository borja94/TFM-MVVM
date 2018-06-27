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
    public partial class TeacherView : Page
    {
        private readonly TeacherFormView _teacherFormView;
        private readonly TeacherCollectionView _teacherCollectionView;
        public TeacherView()
        {
            _teacherCollectionView = new TeacherCollectionView();
            _teacherFormView = new TeacherFormView();
            InitializeComponent();
            teacherCollectionFrame.Navigate(_teacherCollectionView);
            teacherFormFrame.Navigate(_teacherFormView);
            _teacherCollectionView.setTeacherFormView(_teacherFormView);
            _teacherFormView.setTeacherCollectionView(_teacherCollectionView);
        }

        private void returnMenuView(object sender, RoutedEventArgs e)
        {
            MainView menuView = new MainView();
            this.NavigationService.Navigate(menuView);

        }



    }
}
