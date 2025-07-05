using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Authorization.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Authorization.Commands.Handlers
{
	public class AddRolesCommandHandler : ResponseHandler, IRequestHandler<AddRolesCommands, Response<string>>
	{
		private readonly IStringLocalizer<SharedResources.SharedResources> _localization;
		private readonly IAuthorizationServices _authorizationServices;

		public AddRolesCommandHandler(IStringLocalizer<SharedResources.SharedResources> localization, IAuthorizationServices authorizationServices) : base(localization)
		{
			_localization = localization;
			_authorizationServices = authorizationServices;
		}

		public async Task<Response<string>> Handle(AddRolesCommands request, CancellationToken cancellationToken)
		{
			var result = await _authorizationServices.AddRoleAsync(request.RoleName);
			if (result == "Success") return Success("");
			return BadRequest<string>(_localization[SharedResourcesKeys.BadRequest]);
		}
	}
}
