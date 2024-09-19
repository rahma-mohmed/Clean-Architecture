using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolSystem_Infrastructure.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace SchoolSystem_Service.Implementations
{
    internal class StudentService : IStudentService
    {
        #region Filed
        private readonly IStudentRepository _studentRepository;
        #endregion

        #region Constructor
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        #endregion

        #region Handle Functions
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetStudentListAsync();
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student =   _studentRepository.GetTableAsTracking()
                                           .Include(x => x.Departments)
                                           .Where(x => x.Id == id)
                                           .FirstOrDefault();
            return student;
        }

        public Task<string> AddAsync(Student student)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
