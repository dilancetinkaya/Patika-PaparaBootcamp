using AutoMapper;
using RepositoryPattern.Data.Abstract;
using RepositoryPattern.Data.Dtos;
using RepositoryPattern.Domain.Entities;
using RepositoryPattern.Services.Abstracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryPattern.Services.Concretes
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IRepository<Employee> _repository;
        private readonly IMapper _mapper;
        public EmployeeService(IRepository<Employee> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task AddAsync(EmployeeDto employeeDto)
        {
            var employee = _mapper.Map<Employee>(employeeDto);
            await _repository.AddAsync(employee);
        }

        public async Task Delete(int id)
        {
            var employee = await _repository.GetAsync(x => x.Id == id);
            _repository.Delete(employee);

        }

        public async Task<List<EmployeeDto>> GetAllAsync()
        {
            var employees = await _repository.GetAllAsync();
            var employeeDto = _mapper.Map<List<EmployeeDto>>(employees);
            return employeeDto;
        }

        public async Task<EmployeeDto> GetAsync(int id)
        {
            var result = await _repository.GetAsync(x => x.Id == id);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async Task Update(EmployeeDto employeeDto, int id)
        {
            var updatedEmployee = _mapper.Map<Employee>(employeeDto);
            updatedEmployee.Id = id;
            _repository.Update(updatedEmployee);

        }
    }
}
