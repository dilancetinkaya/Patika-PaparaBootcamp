using RepositoryPattern.Data.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Abstracts
{
    public interface IEmployeeService
    {
        Task AddAsync(EmployeeDto employeeDto);
        Task Delete(int id);
        Task Update(EmployeeDto employeeDto, int id);
        Task<List<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto> GetAsync(int id);
    }
}
