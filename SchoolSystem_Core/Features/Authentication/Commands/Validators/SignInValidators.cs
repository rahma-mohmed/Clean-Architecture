using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.Authentication.Commands.Models;
using SchoolSystem_Core.SharedResources;

namespace SchoolSystem_Core.Features.Authentication.Commands.Validators
{
	public class SignInValidators : AbstractValidator<SignInCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructors
		public SignInValidators(IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;

			ApplyValidateRules();
			ApplyCustomValidateRules();
		}
		#endregion

		#region Handle Function
		public void ApplyValidateRules()
		{
			RuleFor(x => x.UserName).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);

			RuleFor(x => x.Password).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
		}

		public void ApplyCustomValidateRules()
		{
		}
		#endregion
	}
}
