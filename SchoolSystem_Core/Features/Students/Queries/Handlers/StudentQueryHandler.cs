using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Students.Queries.Models;
using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Core.Wrapper;
using SchoolSystem_Service.Implementations;

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
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion

		#region Constructor
		public StudentQueryHandler(IStudentService studentService, IMapper mapper, IStringLocalizer<SharedResources.SharedResources> stringLocalizer) : base(stringLocalizer)
		{
			_studentService = studentService;
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;

		}
		#endregion

		#region Handle Function
		public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
		{
			var studentList = await _studentService.GetAllStudentsAsync();
			var studentListMapper = _mapper.Map<List<GetStudentListResponse>>(studentList);
			var res = Success(studentListMapper);
			res.Meta = new { Count = studentListMapper.Count };
			return res;
		}

		public async Task<Response<GetStudentResponse>> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
		{
			var student = await _studentService.GetByIdAsync(request.Id);
			if (student == null) { return NotFound<GetStudentResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]); }
			else
			{
				var res = _mapper.Map<GetStudentResponse>(student);
				return Success(res);
			}
		}

		public async Task<PaginatedResult<GetStudentPagintedListResponse>> Handle(GetStudentPagintedListQuery request, CancellationToken cancellationToken)
		{
			//replace Mapping => Expression fast access to DB , Func (linq) => Delegate need to translate to make DB understand it so use Expression

			//Expression<Func<Student, GetStudentPagintedListResponse>> expression =
			//	e => new GetStudentPagintedListResponse(e.Id, e.GetLocalized(e.NameAr, e.NameEn), e.GetLocalized(e.NameAr, e.AddressEn), e.GetLocalized(e.Departments.DNameAr, e.Departments.DNameEn));
			//------------------------------------------------------------------------------------------------------------------------------

			//var querable = _studentService.GetStudentsQuerable();
			var FilterQuery = _studentService.FilterStudentPagination(request.OrderBy, request.Search);

			//var pagintedList = await FilterQuery.Select(expression).ToPaginatedListAsync(request.PageNumber, request.PageSize);
			//------------------------------------------------------------------------------------------------------------------------------
			//var pagintedList = await FilterQuery.Select(e => new GetStudentPagintedListResponse(e.Id, e.GetLocalized(e.NameAr, e.NameEn), e.GetLocalized(e.NameAr, e.AddressEn), e.GetLocalized(e.Departments.DNameAr, e.Departments.DNameEn)))
			//	.ToPaginatedListAsync(request.PageNumber, request.PageSize);
			//------------------------------------------------------------------------------------------------------------------------------

			var pagintedList = await _mapper.ProjectTo<GetStudentPagintedListResponse>(FilterQuery)
				.ToPaginatedListAsync(request.PageNumber, request.PageSize);

			pagintedList.Meta = new { Count = pagintedList.Data.Count };
			return pagintedList;
		}
		#endregion
	}
}
