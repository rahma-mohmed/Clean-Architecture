﻿using AutoMapper;
using MediatR;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.Departments.Queries.Models;
using SchoolSystem_Core.Features.Departments.Queries.Response;
using SchoolSystem_Core.SharedResources;
using SchoolSystem_Core.Wrapper;
using SchoolSystem_Service.IService;

namespace SchoolSystem_Core.Features.Departments.Queries.Handlers
{
	public class DepartmentQueryHandler : ResponseHandler,
		IRequestHandler<GetDepartmentByIdQuery, Response<GetDepartmentByIdResponse>>,
		IRequestHandler<GetDepartmentListQuery, PaginatedResult<GetDepartmentListResponse>>
	{
		#region Fields
		private readonly IDepartmentService _departmentService;
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		#endregion


		#region Constructors
		public DepartmentQueryHandler(IStringLocalizer<SharedResources.SharedResources> stringLocalizer
			, IMapper mapper, IDepartmentService departmentService) : base(stringLocalizer)
		{
			_stringLocalizer = stringLocalizer;
			_mapper = mapper;
			_departmentService = departmentService;
		}
		#endregion

		#region HandleFunctions
		public async Task<Response<GetDepartmentByIdResponse>> Handle(GetDepartmentByIdQuery request, CancellationToken cancellationToken)
		{
			//Service GetById - Include
			var response = await _departmentService.GetDepartmentById(request.Id);
			if (response == null) { return NotFound<GetDepartmentByIdResponse>(_stringLocalizer[SharedResourcesKeys.NotFound]); }

			//mapping
			var mapper = _mapper.Map<GetDepartmentByIdResponse>(response);

			return Success(mapper);
		}

		public async Task<PaginatedResult<GetDepartmentListResponse>> Handle(GetDepartmentListQuery request, CancellationToken cancellationToken)
		{
			var response = _departmentService.FilterDepartmentPagination(request.OrderBy, request.Search);
			var pagintedList = await _mapper.ProjectTo<GetDepartmentListResponse>(response)
				.ToPaginatedListAsync(request.PageNumber, request.PageSize);

			pagintedList.Meta = new { Count = pagintedList.Data.Count };
			return pagintedList;
		}
		#endregion
	}
}
