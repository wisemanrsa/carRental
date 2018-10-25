using AutoMapper;
using carRental.DTO;
using carRental.Models;

namespace carRental.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Entity to DTO
            CreateMap<Employee, EmployeeDTO>();


            //DTO to Entity
            CreateMap<EmployeeDTO, Employee>();
            CreateMap<CarTypeDTO, CarType>();
            CreateMap<CarDTO, Car>();
            CreateMap<RentalDTO, Rental>();
            CreateMap<PaymentDTO, Payment>();
        }
    }
}