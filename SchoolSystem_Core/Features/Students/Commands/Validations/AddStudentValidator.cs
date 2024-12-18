using FluentValidation;
using SchoolSystem_Core.Features.Students.Commands.Models;
using SchoolSystem_Service.Implementations;

namespace SchoolSystem_Core.Features.Students.Commands.Validations
{
	public class AddStudentValidator : AbstractValidator<AddStudentCommand>
	{
		#region Fields
		private readonly IStudentService _studentService;
		#endregion

		#region Constructors
		public AddStudentValidator(IStudentService studentService)
		{
			_studentService = studentService;

			ApplyValidateRules();
			ApplyCustomValidateRules();
		}
		#endregion

		#region Handle Function
		public void ApplyValidateRules()
		{
			RuleFor(x => x.Name).NotEmpty().WithMessage("Name Must not Be Empty")
				.NotNull().WithMessage("Name Must Be Null")
				.MaximumLength(10).WithMessage("Max length = 10");

			RuleFor(x => x.Address).NotEmpty().WithMessage("{Address} Must Not Be Empty")
				.NotNull().WithMessage("{Address} Must Not Be Null")
				.MaximumLength(10).WithMessage("Max length = 10");
		}

		public void ApplyCustomValidateRules()
		{
			RuleFor(x => x.Name).MustAsync(async (Key, CancellationToken) => !await _studentService.IsNameExist(Key))
				.WithMessage("Name is already exist");
		}
		#endregion
	}
}
