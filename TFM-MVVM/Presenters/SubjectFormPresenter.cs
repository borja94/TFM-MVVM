using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class SubjectFormPresenter
    {
        private readonly SubjectDao _subjectDao;

        public SubjectFormPresenter()
        {
            _subjectDao = new SubjectDao();
        }

        public void insertNewSubject(Subject subject)
        {
            _subjectDao.insert(subject);
        }

        public void updateNewSubject(Subject subject)
        {
            _subjectDao.update(subject);
        }
    }
}
