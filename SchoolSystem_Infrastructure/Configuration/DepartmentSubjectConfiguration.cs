using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Infrastructure.Configuration
{
	public class DepartmentSubjectConfiguration : IEntityTypeConfiguration<DepartmentSubject>
	{
		public void Configure(EntityTypeBuilder<DepartmentSubject> builder)
		{
			builder.HasKey(x => new { x.SubID, x.DID });
		}
	}
}
