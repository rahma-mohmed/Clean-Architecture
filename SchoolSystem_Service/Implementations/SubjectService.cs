using SchoolSystem_Infrastructure.IRepositories;
using SchoolSystem_Service.IService;

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
