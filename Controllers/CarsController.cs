using System.Linq;
using AutoMapper;
using carRental.DTO;
using carRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace carRental.Controllers {
        public class CarsController : Controller {
        private readonly RentalDbContext context;
        private readonly IMapper mapper;
        public CarsController (RentalDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [Route("api/cars")]
        [HttpPost]
        public ActionResult Add([FromBody] CarDTO car)
        {
            var carExist = context.Car.FirstOrDefault(c => c.RegistrationNumber == car.RegistrationNumber);
            if (carExist != null) return BadRequest("Car already exist");
            var carToSave = mapper.Map<CarDTO, Car>(car);
            context.Car.Add(carToSave);
            context.SaveChanges();
            return Ok();
        }

        [Route("api/cars/{registrationNumber}")]
        public ActionResult Get(string registrationNumber)
        {
            var car = context.Car.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
            if (car == null) return BadRequest("Car does not exist");
            return Ok(car);
        }

        [Route("api/cars")]
        [HttpPut]
        public ActionResult Update([FromBody] CarDTO car)
        {
            var c = context.Car.Where(cc => cc.RegistrationNumber != car.RegistrationNumber);
            if (c == null) return BadRequest("Car does not exist");
            context.Car.Update(mapper.Map<CarDTO, Car>(car));
            context.SaveChanges();
            return Ok();
        }

        [Route("api/cars")]
        public ActionResult GetCars()
        {
            return Ok(context.Car.Where(c => c.Available));
        }
    }
}