using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TFM_MVVM.Models;

namespace TFM_MVVM.Presenters
{
    public class StudentCollectionPresenter
    {
        private readonly StudentDao _studentDao;

        public StudentCollectionPresenter()
        {
            _studentDao = new StudentDao();
        }
        
        public IEnumerable<Student> getAllStudents()
        {
            return _studentDao.getAll();
        }

        public void removeStudent(int id)
        {
            _studentDao.remove(id);
        }
    }
}
