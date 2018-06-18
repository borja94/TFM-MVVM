using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class SubjectCollectionPresenter
    {
        private readonly SubjectDao _subjectDao;

        public SubjectCollectionPresenter()
        {
            _subjectDao = new SubjectDao();
        }
        
        public IEnumerable<Subject> getAllSubjects()
        {
            return _subjectDao.GetAll();
        }

        public void removeSubject(int id)
        {
            _subjectDao.remove(id);
        }
    }
}
