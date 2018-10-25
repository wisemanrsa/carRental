using System.Threading.Tasks;
using carRental.DTO;

namespace carRental.Interfaces
{
    public interface IEmployeesServices
    {
        Task<EmployeeDTO> AddEmployee(EmployeeDTO employee);
        EmployeeDTO SearchEmployee(string staffNumber);
    }
}