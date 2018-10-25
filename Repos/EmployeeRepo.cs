using System.Threading.Tasks;
using carRental.DTO;
using carRental.Interfaces;
using carRental.Models;
using System.Linq;

namespace carRental.Repos
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly RentalDbContext context;
        public EmployeeRepo(RentalDbContext context)
        {
            this.context = context;
        }

        public async Task Add(Employee employee)
        {
            context.Employee.Add(employee);
            await context.SaveChangesAsync();
        }

        public Employee Get(string staffNumber)
        {
            return context.Employee.FirstOrDefault(e => e.StaffNumber.ToString() == staffNumber);
        }

        public async Task AddCarType(CarType carType)
        {
            context.CarType.Add(carType);
            await context.SaveChangesAsync();
        }
    }

}