using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;

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
			modelBuilder.Entity<DepartmentSubject>().HasKey(x => new { x.SubID, x.DID });

			modelBuilder.Entity<Ins_Subject>().HasKey(x => new { x.SubID, x.InsId });

			modelBuilder.Entity<StudentSubject>().HasKey(x => new { x.SubID, x.StudID });

			modelBuilder.Entity<Instructor>()
			.HasOne(x => x.Supervisor).WithMany(x => x.Instructors)
			.HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Department>()
				.HasOne(x => x.Instructor)
				.WithOne(x => x.DepartmentManager)
				.HasForeignKey<Department>(x => x.InsManager)
				.OnDelete(DeleteBehavior.Restrict); ;

			base.OnModelCreating(modelBuilder);
		}
	}
}
