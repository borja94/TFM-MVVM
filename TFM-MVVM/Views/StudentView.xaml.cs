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
    public partial class StudentView : Page
    {
        private readonly StudentFormView _studentFormView;
        private readonly StudentCollectionView _studentCollectionView;
        public StudentView()
        {
            _studentCollectionView = new StudentCollectionView();
            _studentFormView = new StudentFormView();
            InitializeComponent();
            studentCollectionFrame.Navigate(_studentCollectionView);
            studentFormFrame.Navigate(_studentFormView);
            _studentCollectionView.setStudentFormView(_studentFormView);
            _studentFormView.setStudentCollectionView(_studentCollectionView);
        }

        private void returnMenuView(object sender, RoutedEventArgs e)
        {
            MainView menuView = new MainView();
            this.NavigationService.Navigate(menuView);

        }



    }
}
