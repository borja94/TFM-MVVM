using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class StudentFormPresenter
    {
        private readonly StudentDao _studentDao;
        private readonly SubjectDao _subjectDao;

        public StudentFormPresenter()
        {
            _studentDao = new StudentDao();
            _subjectDao = new SubjectDao();
        }

        public void insertNewStudent(Student student)
        {
            _studentDao.insert(student);
        }

        public void updateNewStudent(Student student)
        {
            _studentDao.update(student);
        }

        public IEnumerable<Subject> GetAllSubjects() {
            return _subjectDao.GetAll();
        }

    }
}
