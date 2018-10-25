using System.Threading.Tasks;
using carRental.Models;

namespace carRental.Interfaces
{
    public interface IEmployeeRepo
    {
        Task Add(Employee employee);
        Employee Get(string staffNumber);
        Task AddCarType(CarType carType);
    }
}