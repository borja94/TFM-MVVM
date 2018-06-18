
using System.Collections.Generic;

namespace TFM_MVVM.Models
{
    
    public class Student
    {
        public Student()
        {
            Subjects = new List<Subject>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }    
        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}
