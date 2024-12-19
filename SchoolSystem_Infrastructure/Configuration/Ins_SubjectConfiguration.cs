using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolSystem_Data.Entities;

namespace SchoolSystem_Infrastructure.Configuration
{
	public class Ins_SubjectConfiguration : IEntityTypeConfiguration<Ins_Subject>
	{
		public void Configure(EntityTypeBuilder<Ins_Subject> builder)
		{
			builder.HasKey(x => new { x.SubID, x.InsId });
		}
	}
}
