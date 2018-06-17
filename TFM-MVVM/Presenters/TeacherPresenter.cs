using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class TeacherPresenter
    {
        private readonly TeacherDao _teacherDao;
        private readonly SubjectDao _subjectDao;

        public TeacherPresenter()
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

        public IEnumerable<Teacher> getAllTeachers()
        {
            return _teacherDao.getAll();
        }

        public void removeTeacher(int id)
        {
            _teacherDao.remove(id);
        }

        public IEnumerable<Subject> GetAllSubjects() {
            return _subjectDao.GetAll();
        }

    }
}
