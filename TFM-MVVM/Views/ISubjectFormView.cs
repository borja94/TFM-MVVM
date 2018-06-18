using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Views
{
    public interface ISubjectFormView
    {
        void editSubjectMode(Subject subject);
        void newSubjectMode();

    }
}
