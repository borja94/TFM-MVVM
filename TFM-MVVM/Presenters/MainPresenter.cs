using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class MainPresenter
    {
        private readonly StudentDao _studentDao;
        private readonly SubjectDao _subjectDao;
        private readonly TeacherDao _teacherDao;

        public MainPresenter()
        {
            _studentDao = new StudentDao();
            _subjectDao = new SubjectDao();
            _teacherDao = new TeacherDao();
        }

        public int GetNumTeachers()
        {
            return _teacherDao.getAll().Count;
        }
        public int GetNumStudents()
        {
            return _studentDao.getAll().Count;
        }
        public int GetNumSubjects()
        {
            return _subjectDao.GetAll().ToList().Count;
        }

    }
}
