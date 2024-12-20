using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.User.Commands.Models;

namespace SchoolSystem_Core.Features.User.Commands.Handlers
{
	public class UserCommandHandlers : ResponseHandler, IRequestHandler<AddUserCommand, Response<string>>
	{
		#region Fields
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		private readonly UserManager<SchoolSystem_Data.Entities.Identity.User> _userManager;
		#endregion

		#region Constructor
		public UserCommandHandlers(IMapper mapper,
			UserManager<SchoolSystem_Data.Entities.Identity.User> userManager,
			IStringLocalizer<SharedResources.SharedResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
		}
		#endregion

		#region Handle Functions
		public async Task<Response<string>> Handle(AddUserCommand request, CancellationToken cancellationToken)
		{
			//If email exist
			var userByEmail = await _userManager.FindByEmailAsync(request.Email);
			if (userByEmail != null)
			{
				return BadRequest<string>(_stringLocalizer[SharedResources.SharedResourcesKeys.EmailExist]);
			}

			var userByName = await _userManager.FindByNameAsync(request.UserName);
			if (userByName != null)
			{
				return BadRequest<string>(_stringLocalizer[SharedResources.SharedResourcesKeys.UserNameExist]);
			}

			//Mapping
			var IdentityUser = _mapper.Map<SchoolSystem_Data.Entities.Identity.User>(request);

			var createResult = await _userManager.CreateAsync(IdentityUser, request.Password);

			if (!createResult.Succeeded) return BadRequest<string>($"{_stringLocalizer[SharedResources.SharedResourcesKeys.RegisterFaild]}, {createResult.Errors.FirstOrDefault().Description}");

			return Created("");
		}
		#endregion
	}
}
