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
    public partial class SubjectView : Page
    {
        private readonly SubjectFormView _subjectFormView;
        private readonly SubjectCollectionView _subjectCollectionView;
        public SubjectView()
        {
            _subjectCollectionView = new SubjectCollectionView();
            _subjectFormView = new SubjectFormView();
            InitializeComponent();
            subjectCollectionFrame.Navigate(_subjectCollectionView);
            subjectFormFrame.Navigate(_subjectFormView);
            _subjectCollectionView.setSubjectFormView(_subjectFormView);
            _subjectFormView.setSubjectCollectionView(_subjectCollectionView);
        }

        private void returnMenuView(object sender, RoutedEventArgs e)
        {
            Menu menuView = new Menu();
            this.NavigationService.Navigate(menuView);

        }



    }
}
