using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class TeacherCollectionPresenter
    {
        private readonly TeacherDao _teacherDao;

        public TeacherCollectionPresenter()
        {
            _teacherDao = new TeacherDao();
        }
        
        public IEnumerable<Teacher> getAllTeachers()
        {
            return _teacherDao.getAll();
        }

        public void removeTeacher(int id)
        {
            _teacherDao.remove(id);
        }
    }
}
