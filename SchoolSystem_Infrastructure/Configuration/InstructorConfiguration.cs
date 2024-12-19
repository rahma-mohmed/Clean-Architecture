using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Infrastructure.Configuration
{
	public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
	{
		public void Configure(EntityTypeBuilder<Instructor> builder)
		{
			builder.HasOne(x => x.Supervisor).WithMany(x => x.Instructors)
			.HasForeignKey(x => x.SupervisorId).OnDelete(DeleteBehavior.Restrict);
		}
	}
}
