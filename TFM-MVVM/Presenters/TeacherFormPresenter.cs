using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class TeacherFormPresenter
    {
        private readonly TeacherDao _teacherDao;
        private readonly SubjectDao _subjectDao;

        public TeacherFormPresenter()
        {
            _teacherDao = new TeacherDao();
            _subjectDao = new SubjectDao();
        }

        public void insertNewTeacher(Teacher teacher)
        {
            _teacherDao.insert(teacher);
        }

        public void updateNewTeacher(Teacher teacher)
        {
            _teacherDao.update(teacher);
        }

        public IEnumerable<Subject> GetAllSubjects() {
            return _subjectDao.GetAll();
        }

    }
}
