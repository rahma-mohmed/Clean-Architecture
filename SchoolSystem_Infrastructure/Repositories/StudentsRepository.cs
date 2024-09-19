using Microsoft.EntityFrameworkCore;
using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.Context;
using SchoolSystem_Infrastructure.InfrastructureBase;
using SchoolSystem_Infrastructure.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem_Infrastructure.Repositories
{
    public class StudentsRepository: GenericRepositoryAsync<Student>,IStudentRepository
    {
        #region Fields
        private readonly DbSet<Student> _dBContext;
        #endregion

        #region Constructor
        public StudentsRepository(ApplicationDBContext dBContext):base(dBContext)
        {
            _dBContext = dBContext.Set<Student>();
        }

        #endregion

        #region Handle Functions

        public async Task<List<Student>> GetStudentListAsync()
        {
            return await _dBContext.Include(s => s.Departments).ToListAsync();
        }

        #endregion
    }
}
