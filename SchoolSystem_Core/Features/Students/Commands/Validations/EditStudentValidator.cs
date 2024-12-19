using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Service.Implementations;

namespace SchoolSystem_Core.Features.Students.Commands.Validations
{
	public class EditStudentValidator : AbstractValidator<EditStudentCommand>
	{
		#region Fields
		private readonly IStudentService _studentService;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructors
		public EditStudentValidator(IStudentService studentService, IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_studentService = studentService;
			_stringLocalizer = stringLocalizer;

			ApplyValidateRules();
			ApplyCustomValidateRules();
		}
		#endregion

		#region Handle Function
		public void ApplyValidateRules()
		{
			RuleFor(x => x.NameAr).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);

			RuleFor(x => x.NameEn).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);

			RuleFor(x => x.AddressAr).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);

			RuleFor(x => x.AddressEn).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);
		}

		public void ApplyCustomValidateRules()
		{
			RuleFor(x => x.NameAr).MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

			RuleFor(x => x.NameEn).MustAsync(async (model, Key, CancellationToken) => !await _studentService.IsNameExistExcludeSelf(Key, model.Id))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);
		}
		#endregion
	}
}
