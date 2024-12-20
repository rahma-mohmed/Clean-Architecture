using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Service.Implementations;

namespace SchoolSystem_Core.Features.Students.Commands.Validations
{
	public class AddStudentValidator : AbstractValidator<AddStudentCommand>
	{
		#region Fields
		private readonly IStudentService _studentService;
		private readonly IDepartmentService _departmentService;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructors
		public AddStudentValidator(IStudentService studentService, IDepartmentService departmentService, IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_studentService = studentService;
			_stringLocalizer = stringLocalizer;
			_departmentService = departmentService;

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
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.AddressEn).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);

			RuleFor(x => x.DepartmentId).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required]);
		}

		public void ApplyCustomValidateRules()
		{
			RuleFor(x => x.NameAr).MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

			RuleFor(x => x.NameEn).MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

			When(p => p.DepartmentId != null, () =>
			{
				RuleFor(x => x.DepartmentId).MustAsync(async (Key, CancellationToken) => await _departmentService.IsDepartmentIdExist(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.DepartmentIdNotExist]);
			});
		}
		#endregion
	}
}
