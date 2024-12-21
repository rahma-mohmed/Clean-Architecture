using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.User.Commands.Models;
using SchoolSystem_Core.SharedResources;

namespace SchoolSystem_Core.Features.User.Commands.Validators
{
	public class ChangeUserPasswordValidator : AbstractValidator<ChangeUserPasswordCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructors
		public ChangeUserPasswordValidator(IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;

			ApplyValidateRules();
			ApplyCustomValidateRules();
		}
		#endregion

		#region Handle Function
		public void ApplyValidateRules()
		{
			RuleFor(x => x.Id).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.OldPassword).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.NewPassword).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.ConfirmNewPassword).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.Equal(x => x.NewPassword).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordMatch]);
		}

		public void ApplyCustomValidateRules()
		{

		}
		#endregion
	}
}
