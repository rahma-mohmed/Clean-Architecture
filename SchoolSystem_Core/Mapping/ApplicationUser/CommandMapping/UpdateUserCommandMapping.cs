using SchoolSystem_Core.Features.User.Commands.Models;
using SchoolSystem_Data.Entities.Identity;

namespace SchoolSystem_Core.Mapping.ApplicationUser
{
	public partial class ApplicationUserProfile
	{
		public void UpdateUserCommandMapping()
		{
			CreateMap<UpdateUserCommand, User>();
		}
	}
}
