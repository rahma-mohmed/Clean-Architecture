using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.Authorization.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Authorization.Commands.Validators
{
	public class AddRolesValidators : AbstractValidator<AddRolesCommands>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		private readonly IAuthorizationServices _authorizationServices;
		#endregion

		#region Constructor
		public AddRolesValidators(IStringLocalizer<SharedResources.SharedResources> stringLocalizer, IAuthorizationServices authorizationServices)
		{
			_stringLocalizer = stringLocalizer;
			_authorizationServices = authorizationServices;

			ApplyValidationRules();
			ApplyCustomValidationRules();
		}
		#endregion

		#region Actions
		public void ApplyValidationRules()
		{
			RuleFor(x => x.RoleName).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty]);
		}

		public void ApplyCustomValidationRules()
		{
			RuleFor(x => x.RoleName).MustAsync(async (key, CancellationToken) => !await _authorizationServices.IsRoleExist(key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);
		}
		#endregion

	}
}
