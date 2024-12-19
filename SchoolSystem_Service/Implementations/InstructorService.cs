using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Service.Implementations
{
	public class InstructorService : IInstructorService
	{
		#region Fields
		private readonly IInstructorRepository _repository;
		#endregion

		#region Constructors
		public InstructorService(IInstructorRepository repository)
		{
			_repository = repository;
		}
		#endregion

		#region Handle Function
		#endregion
	}
}
