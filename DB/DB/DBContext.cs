using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Model;

namespace Infrastructure.DB
{
    public class CollegeDBContext : DbContext
    {        
        public CollegeDBContext() : base("DBContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
            //Database.SetInitializer<CollegeDBContext>(new CreateDatabaseIfNotExists<CollegeDBContext>());
            //Database.SetInitializer<CollegeDBContext>(new DropCreateDatabaseAlways<CollegeDBContext>());
           // Database.SetInitializer<CollegeDBContext>(new DropCreateDatabaseIfModelChanges<CollegeDBContext>());
            //Database.SetInitializer<CollegeDBContext>(new Infrastructure.Seed.CollegeInitializer());            
        }

        public DbSet<Student> Student { get; set; }
        public DbSet<Teacher> Teacher { get; set; }
        public DbSet<Subject> Subject { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Grade> Grade { get; set; }
        public DbSet<RelationshipsStudentSubject> RelationshipsStudentSubject { get; set; }
        public DbSet<RelationshipsTeacherSubject> RelationshipsTeacherSubject { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<Subject>().Ignore(t => t.CourseName1);
            base.OnModelCreating(modelBuilder);
        }
    }
}
