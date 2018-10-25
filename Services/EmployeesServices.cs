using System.Threading.Tasks;
using AutoMapper;
using carRental.DTO;
using carRental.Interfaces;
using carRental.Models;

namespace carRental.Services
{
    public class EmployeesService : IEmployeesServices
    {
        private readonly IEmployeeRepo empRepo;
        private readonly IMapper mapper;
        public EmployeesService(IEmployeeRepo empRepo, IMapper mapper)
        {
            this.mapper = mapper;
            this.empRepo = empRepo;
        }

        public async Task<EmployeeDTO> AddEmployee(EmployeeDTO employee)
        {
            var emp = GetEmployee(employee.StaffNumber);
            if (emp != null) return new EmployeeDTO {ErrorMessage = $"Employee with staff number: {employee.StaffNumber} already exist"};
            await empRepo.Add(mapper.Map<EmployeeDTO, Employee>(employee));
            return employee;
        }

        public Employee GetEmployee(string staffNumber)
        {
            return empRepo.Get(staffNumber);
        }

        public EmployeeDTO SearchEmployee(string staffNumber)
        {
            return mapper.Map<Employee, EmployeeDTO>(GetEmployee(staffNumber));
        }
    }
}