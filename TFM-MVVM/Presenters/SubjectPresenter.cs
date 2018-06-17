using System.Collections.Generic;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class SubjectPresenter
    {
        private readonly SubjectDao _subjectDao;
        public SubjectPresenter()
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
