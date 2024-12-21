using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Infrastructure.Configuration
{
	public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.HasOne(x => x.Instructor)
			.WithOne(x => x.DepartmentManager)
			.HasForeignKey<Department>(x => x.InsManager)
			.OnDelete(DeleteBehavior.Restrict);

			builder.HasMany(d => d.Students)
			.WithOne(d => d.Departments)
			.HasForeignKey(s => s.DID)
			.OnDelete(DeleteBehavior.SetNull);

			builder.HasMany(d => d.Instructors)
			.WithOne(d => d.Department)
			.HasForeignKey(s => s.DID)
			.OnDelete(DeleteBehavior.SetNull);
		}
	}
}
