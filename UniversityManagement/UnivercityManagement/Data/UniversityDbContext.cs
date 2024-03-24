using Microsoft.EntityFrameworkCore;
using UniversityManagement.Entities;

namespace UniversityManagement.Data
{
    public class UniversityDbContext : DbContext
    {
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Instructor> Instructors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseAssignment> CourseAssignments { get; set; }
        public virtual DbSet<Enrollment> Enrollments { get; set; }
        public virtual DbSet<Student> Students { get; set; } 
        public UniversityDbContext(DbContextOptions<UniversityDbContext> options) 
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseAssignment>().ToTable(nameof(CourseAssignment));
            modelBuilder.Entity<CourseAssignment>().HasKey(x => x.Id);
            modelBuilder.Entity<CourseAssignment>().Property(x => x.Room)
                .HasMaxLength(15)
                .IsRequired();
            modelBuilder.Entity<CourseAssignment>()
                .HasOne(x => x.Instructor)
                .WithMany(i => i.Assignments)
                .HasForeignKey(x => x.InstructorId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<CourseAssignment>()
                .HasOne(x => x.Course)
                .WithMany(c => c.Assignments)
                .HasForeignKey(x => x.CourseId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Enrollment>().ToTable(nameof(Enrollment));
            modelBuilder.Entity<Enrollment>()
                .HasOne(x => x.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(x => x.StudentId)
                .OnDelete(DeleteBehavior.NoAction);
            modelBuilder.Entity<Enrollment>()
                .HasOne(x => x.CourseAssignment)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(x => x.AssignmentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Student>().ToTable(nameof(Student));
            modelBuilder.Entity<Student>().HasKey(x => x.Id);
            modelBuilder.Entity<Student>().Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Student>().Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(25);
            modelBuilder.Entity<Student>().Property(x => x.Grade)
                .IsRequired()
                .HasDefaultValue(1);


            base.OnModelCreating(modelBuilder);
        }
    }
}
