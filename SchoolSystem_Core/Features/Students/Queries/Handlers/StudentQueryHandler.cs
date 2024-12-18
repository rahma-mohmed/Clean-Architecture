using MediatR;
using SchoolSystem_Core.Features.Students.Queries.Models;
using SchoolSystem_Core.Features.Students.Queries.Response;
using SchoolSystem_Infrastructure.IRepositories;
using AutoMapper;
using SchoolSystem_Core.Basis;

namespace SchoolSystem_Core.Features.Students.Queries.Handlers
{
    public class StudentQueryHandler : ResponseHandler,
                                 IRequestHandler<GetStudentListQuery, Response<List<GetStudentListResponse>>>,
                                 IRequestHandler<GetStudentByIdQuery, Response<GetStudentResponse>>
    {
        #region Fields
        private readonly IStudentRepository _studentService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructor
        public StudentQueryHandler(IStudentRepository studentService , IMapper mapper)
        {
            _studentService = studentService;
            _mapper = mapper;
        }
        #endregion

        public async Task<Response<List<GetStudentListResponse>>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            var studentList = await _studentService.GetStudentListAsync();
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
    }
}
