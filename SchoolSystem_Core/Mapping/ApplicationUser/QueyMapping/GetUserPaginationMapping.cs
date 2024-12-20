using SchoolSystem_Core.Features.User.Queries.Result;
using SchoolSystem_Data.Entities.Identity;

namespace SchoolSystem_Core.Mapping.ApplicationUser
{
	public partial class ApplicationUserProfile
	{
		public void GetUserPaginationMapping()
		{
			CreateMap<User, GetUserListResponse>();
		}
	}
}
