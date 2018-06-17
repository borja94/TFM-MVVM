namespace TFM_MVVM.Models
{
    using System.Collections.Generic;
    
    public class Teacher
    {
        public Teacher()
        {
            Subjects = new List<Subject>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    
        public virtual IEnumerable<Subject> Subjects { get; set; }
    }
}
