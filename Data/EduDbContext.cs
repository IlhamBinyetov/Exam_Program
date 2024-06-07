using Exam_Program.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.JSInterop;

namespace Exam_Program.Data
{
    public class EduDbContext : DbContext
    {

        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Exam> Exams { get; set; }



        public IConfiguration Configuration;

        public EduDbContext(DbContextOptions<EduDbContext> options, IConfiguration configuration) :base(options)
        {
            Configuration = configuration;
        }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder.IsConfigured) return;
            var dbConnection = Configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(dbConnection);
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Lesson>()
            .HasIndex(l => l.Code)
            .IsUnique(); // Add unique constraint to LessonCode

            modelBuilder.Entity<Exam>()
                .HasOne(s => s.Lesson)
                .WithMany(s => s.Exams)
                .HasForeignKey(s => s.LessonCode)
                .HasPrincipalKey(s=>s.Code)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Exam>()
                .HasOne(s => s.Student)
                .WithMany(s => s.Exams)
                .HasForeignKey(s => s.StudentNumber)
                .HasPrincipalKey(s=>s.StudentNumber)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}



