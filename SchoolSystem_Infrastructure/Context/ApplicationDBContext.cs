using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using System.Reflection;

namespace SchoolSystem_Infrastructure.Context
{
	public class ApplicationDBContext : DbContext
	{
		public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
		{

		}

		public ApplicationDBContext()
		{

		}

		public DbSet<Student> Students { get; set; }
		public DbSet<Department> Departments { get; set; }
		public DbSet<Subject> Subjects { get; set; }
		public DbSet<DepartmentSubject> DepartmentSubjects { get; set; }
		public DbSet<StudentSubject> StudentSubjects { get; set; }

		//protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		//{
		//    base.OnConfiguring(optionsBuilder);
		//}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			//لتطبيق الكونفيجرشن المتنفذه في اي مكان
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
