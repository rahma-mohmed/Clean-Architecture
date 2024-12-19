using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Infrastructure.Configuration
{
	public class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
	{
		public void Configure(EntityTypeBuilder<StudentSubject> builder)
		{
			builder.HasKey(x => new { x.SubID, x.StudID });
		}
	}
}
