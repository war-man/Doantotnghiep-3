using DOAN_CHuyenNGanh.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace IdentitySample.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Action> Actions { get; set; }
        public DbSet<RoleAction> RoleActions { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<ClassTeacher> ClassTeacher { get; set; }
        public DbSet<SetColumnContact> SetColumnContact { get; set; }
        public DbSet<FocusExams> FocusExamses { get; set; }
        public DbSet<HomeRoomTeacher> HomeRoomTeachers { get; set; }
        public DbSet<ClassStudent> ClassStudent { get; set; }
        public DbSet<ScheduleTeacher> ScheduleTeacher { get; set; }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoleAction>()
                .HasRequired(a=>a.Action).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>().HasRequired(a => a.CLass).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>().HasRequired(a => a.Student).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>().HasRequired(a => a.Subject).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>().HasRequired(a => a.Semester).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Contact>().HasRequired(a => a.Year).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<Teacher>().HasRequired(a=>a.Class).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Post>().HasRequired(a => a.Category).WithMany().WillCascadeOnDelete(false);

            //modelBuilder.Entity<ClassTeacher>().HasRequired(a => a.Class).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ClassTeacher>().HasRequired(a => a.Teacher).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ClassTeacher>().HasRequired(a => a.Subject).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<ClassStudent>().HasRequired(a => a.Student).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ClassStudent>().HasRequired(a => a.Class).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<ClassStudent>().HasRequired(a => a.Year).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<HomeRoomTeacher>().HasRequired(a => a.Class).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<HomeRoomTeacher>().HasRequired(a => a.Year).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<SetColumnContact>().HasRequired(a => a.Teacher).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<SetColumnContact>().HasRequired(a => a.Year).WithMany().WillCascadeOnDelete(false);


            modelBuilder.Entity<FocusExams>().HasRequired(a => a.Subject).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<FocusExams>().HasRequired(a => a.Semester).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<FocusExams>().HasRequired(a => a.Year).WithMany().WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}