using AutoMapper;
using MediatR;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Students.Queries.Models;
using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Core.Wrapper;
using SchoolSystem_Data.Entities;
using SchoolSystem_Service.Implementations;
using System.Linq.Expressions;

namespace SchoolSystem_Core.Features.Students.Queries.Handlers
{
	public class StudentQueryHandler : ResponseHandler,
								 IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
								 IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>,
								 IRequestHandler<GetStudentPagintedListQuery, PaginatedResult<GetStudentPagintedListResponse>>

	{
		#region Fields
		private readonly IStudentService _studentService;
		private readonly IMapper _mapper;
		#endregion

		#region Constructor
		public StudentQueryHandler(IStudentService studentService, IMapper mapper)
		{
			_studentService = studentService;
			_mapper = mapper;
		}
		#endregion

		#region Handle Function
		public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var studentList = await _studentService.GetAllStudentsAsync();
			var res = _mapper.Map<List<GetStudentListResponse>>(studentList);
			return Success(res);
		}

		public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetByIdAsync(request.Id);
			if (student == null) { return NotFound<GetStudentResponse>("Student Not Found"); }
			else
			{
				var res = _mapper.Map<GetStudentResponse>(student);
				return Success(res);
			}
		}

		public async Task<PaginatedResult<GetStudentPagintedListResponse>> Handle(GetStudentPagintedListQuery request, CancellationToken cancellationToken)
		{
			//replace Mapping => Expression fast access to DB , Func (linq) => Delegate need to translate to make DB understand it so use Expression
			Expression<Func<Student, GetStudentPagintedListResponse>> expression =
				e => new GetStudentPagintedListResponse(e.Id, e.Name, e.Address, e.Departments.DName);

			//var querable = _studentService.GetStudentsQuerable();
			var FilterQuery = _studentService.FilterStudentPagination(request.OrderBy, request.Search);
			var pagintedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
			return pagintedList;

		}
		#endregion
	}
}
