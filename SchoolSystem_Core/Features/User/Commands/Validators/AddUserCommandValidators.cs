using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.User.Commands.Models;
using SchoolSystem_Core.SharedResources;

namespace SchoolSystem_Core.Features.User.Commands.Validators
{
	public class AddUserCommandValidators : AbstractValidator<AddUserCommand>
	{
		#region Fields
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructors
		public AddUserCommandValidators(IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;

			ApplyValidateRules();
			ApplyCustomValidateRules();
		}
		#endregion

		#region Handle Function
		public void ApplyValidateRules()
		{
			RuleFor(x => x.FullName).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);

			RuleFor(x => x.Password).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.Equal(x => x.Password).WithMessage(_stringLocalizer[SharedResourcesKeys.PasswordMatch]);

			RuleFor(x => x.Email).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.UserName).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
		}

		public void ApplyCustomValidateRules()
		{

		}
		#endregion
	}
}
