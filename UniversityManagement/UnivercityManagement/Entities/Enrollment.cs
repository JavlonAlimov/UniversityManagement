using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Entities
{
    public class Enrollment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
        public int AssignmentId { get; set; }
        public CourseAssignment? CourseAssignment { get; set; }
    }
}
