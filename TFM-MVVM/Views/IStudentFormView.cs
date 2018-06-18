using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Views
{
    public interface IStudentFormView
    {
        void editStudentMode(Student student);
        void newStudentMode();

    }
}
