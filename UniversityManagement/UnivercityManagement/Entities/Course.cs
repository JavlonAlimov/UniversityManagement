﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniversityManagement.Entities
{
    [Table(nameof(Course))]
    public class Course
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required,
            MinLength(5, ErrorMessage = "Course name should contain at least 5 characters."),
            MaxLength(255, ErrorMessage = "Maximum amount of characters exceeded.")]
        public string Name { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        public int Hours { get; set; }
        [ForeignKey(nameof(DepartmentId))]
        public int DepartmentId {  get; set; }
        public Department? Department { get; set; }

        public virtual ICollection<CourseAssignment> Assignments { get; set; }
        public Course()
        {
            Assignments = new List<CourseAssignment>();
        }
    }
}
