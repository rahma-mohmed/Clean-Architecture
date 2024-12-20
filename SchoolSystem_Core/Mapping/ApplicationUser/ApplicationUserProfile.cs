using AutoMapper;

namespace SchoolSystem_Core.Mapping.ApplicationUser
{
	public partial class ApplicationUserProfile : Profile
	{
		public ApplicationUserProfile()
		{
			AddUserCommandMapping();
			GetUserPaginationMapping();
			GetUserByIdMapping();
		}
	}
}
