using SchoolSystem_Infrastructure.IRepositories;

namespace SchoolSystem_Service.Implementations
{
	public class SubjectService : ISubjectService
	{
		#region Fields
		private readonly ISubjectRepository _repository;
		#endregion

		#region Constructors
		public SubjectService(ISubjectRepository repository)
		{
			_repository = repository;
		}
		#endregion

		#region Handle Function
		#endregion
	}
}
