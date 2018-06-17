using System;
using System.Collections.Generic;
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

namespace TFM_MVVM.Views
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Page
    {
        public Menu()
        {
            InitializeComponent();
        }

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
    }
}
