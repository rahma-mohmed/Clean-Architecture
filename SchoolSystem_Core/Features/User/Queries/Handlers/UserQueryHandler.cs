using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using SchoolSystem_Core.Basis;
using SchoolSystem_Core.Features.User.Queries.Models;
using SchoolSystem_Core.Features.User.Queries.Result;
using SchoolSystem_Core.Wrapper;

namespace SchoolSystem_Core.Features.User.Queries.Handlers
{
	public class UserQueryHandler : ResponseHandler
		, IRequestHandler<GetUserListQuery, PaginatedResult<GetUserListResponse>>
		, IRequestHandler<GetUserById, Response<GetUserByIdResponse>>
	{
		#region Fields
		private readonly IMapper _mapper;
		private readonly IStringLocalizer<SharedResources.SharedResources> _stringLocalizer;
		private readonly UserManager<SchoolSystem_Data.Entities.Identity.User> _userManager;
		#endregion

		public UserQueryHandler(UserManager<SchoolSystem_Data.Entities.Identity.User> userManager, IMapper mapper, IStringLocalizer<SharedResources.SharedResources> stringLocalizer) : base(stringLocalizer)
		{
			_mapper = mapper;
			_stringLocalizer = stringLocalizer;
			_userManager = userManager;
		}

		public async Task<PaginatedResult<GetUserListResponse>> Handle(GetUserListQuery request, CancellationToken cancellationToken)
		{
			var users = _userManager.Users.AsQueryable();
			var paginatedList = await _mapper.ProjectTo<GetUserListResponse>(users).ToPaginatedListAsync(request.pageNumber, request.pageSize);
			return paginatedList;
		}

		public async Task<Response<GetUserByIdResponse>> Handle(GetUserById request, CancellationToken cancellationToken)
		{
			var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id);
			if (user == null)
			{
				return NotFound<GetUserByIdResponse>(_stringLocalizer[SharedResources.SharedResourcesKeys.NotFound]);
			}
			var res = _mapper.Map<GetUserByIdResponse>(user);
			return Success(res);
		}
	}
}
