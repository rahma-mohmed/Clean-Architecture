using FluentValidation;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Features.Departments.Commands.Models;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Departments.Commands.Validators
{
	public class UpdateDepartmentValidator : AbstractValidator<UpdateDepartmentCommand>
	{
		#region Fields
		private readonly IDepartmentService _departmentService;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructor
		public UpdateDepartmentValidator(IDepartmentService departmentService, IStringLocalizer<SharedResources.SharedResources> stringLocalizer)
		{
			_departmentService = departmentService;
			_stringLocalizer = stringLocalizer;

			ApplyValidateRules();
			ApplyCustomValidateRules();
		}
		#endregion

		#region Handle Function
		public void ApplyValidateRules()
		{
			RuleFor(x => x.DNameAr).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);

			RuleFor(x => x.DNameEn).NotEmpty().WithMessage(_stringLocalizer[SharedResourcesKeys.NotEmpty])
				.NotNull().WithMessage(_stringLocalizer[SharedResourcesKeys.Required])
				.MaximumLength(100).WithMessage(_stringLocalizer[SharedResourcesKeys.MaxLengthIs100]);
		}

		public void ApplyCustomValidateRules()
		{
			RuleFor(x => x.DNameAr).MustAsync(async (Key, CancellationToken) => !await _departmentService.IsDepartmentExist(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

			RuleFor(x => x.DNameEn).MustAsync(async (Key, CancellationToken) => !await _departmentService.IsDepartmentExist(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.Exist]);

			When(p => p.InsManager != null, () =>
			{
				RuleFor(x => x.InsManager).MustAsync(async (Key, CancellationToken) => await _departmentService.IsInstructorIdExist(Key))
				.WithMessage(_stringLocalizer[SharedResourcesKeys.InstructorIdNotExist]);
			});
		}
		#endregion
	}
}
