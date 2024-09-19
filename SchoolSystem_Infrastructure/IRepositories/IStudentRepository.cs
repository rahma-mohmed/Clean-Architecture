using SchoolSystem_Data.Entities;
using SchoolSystem_Infrastructure.InfrastructureBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolSystem_Infrastructure.IRepositories
{
    public interface IStudentRepository: IGenericRepositoryAsync<Student>
    {
        public Task<List<Student>> GetStudentListAsync();
    }
}
