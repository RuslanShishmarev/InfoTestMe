using Microsoft.EntityFrameworkCore;

namespace InfoTestMe.Admin.Web.Models.Data
{
    public class InfoTestMeDataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Author> Authors { get; set; }

        //for courses
        public DbSet<Course> Courses { get; set; }
        public DbSet<CourseTheme> CourseThemes { get; set; }
        public DbSet<CoursePage> CoursePages { get; set; }
        public DbSet<CourseBlock> CourseBlocks { get; set; }

        //for tests
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }

        public InfoTestMeDataContext(DbContextOptions<InfoTestMeDataContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
    }
}
