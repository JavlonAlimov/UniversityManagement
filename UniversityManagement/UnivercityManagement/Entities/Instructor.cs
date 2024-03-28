using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Entities
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string FullName => FirstName + " " + LastName;
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department?  Department{ get; set; }

        public virtual ICollection<CourseAssignment> Assignments { get; set; }

        public Instructor()
        {
            Assignments = new List<CourseAssignment>();
        }


    }
}
