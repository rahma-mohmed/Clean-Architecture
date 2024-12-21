using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.User.Commands.Models;

namespace SchoolSystem_Core.Features.User.Commands.Handlers
{
	public class UserCommandHandlers : ResponseHandler
		, IRequestHandler<AddUserCommand, Response<string>>
		, IRequestHandler<UpdateUserCommand, Response<string>>
		, IRequestHandler<DeleteUserCommand, Response<string>>
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

		public async Task<Response<string>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
			if (user == null)
			{
				return NotFound<string>(_stringLocalizer[SharedResources.SharedResourcesKeys.NotFound]);
			}
			var newUser = _mapper.Map(request, user);

			var res = await _userManager.UpdateAsync(newUser);

			if (res.Succeeded)
			{
				return Success($"{_stringLocalizer[SharedResources.SharedResourcesKeys.Updated]}");
			}

			return BadRequest<string>(_stringLocalizer[SharedResources.SharedResourcesKeys.UpdateFailed]);
		}

		public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
		{
			var user = await _userManager.FindByIdAsync(request.Id.ToString());

			if (user == null) return NotFound<string>();

			var res = await _userManager.DeleteAsync(user);

			if (res.Succeeded) return Success($"{_stringLocalizer[SharedResources.SharedResourcesKeys.DeletedSuccess]}");

			return BadRequest<string>(_stringLocalizer[SharedResources.SharedResourcesKeys.DeletedFailed]);
		}
		#endregion
	}
}
