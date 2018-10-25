using System.Linq;
using AutoMapper;
using carRental.DTO;
using carRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace carRental.Controllers
{
    
    public class CarTypesController : Controller
    {
        private readonly RentalDbContext context;
        private readonly IMapper mapper;

        public CarTypesController(RentalDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [Route("api/cartype")]
        [HttpPost]
        public ActionResult AddCarType([FromBody] CarTypeDTO carType)
        {
            var temp = context.CarType.FirstOrDefault(cc => cc.Code == carType.Code);
            if (temp != null) return BadRequest("Car type already exist");
            var c = mapper.Map<CarTypeDTO, CarType>(carType);
            context.CarType.Add(c);
            context.SaveChanges();
            return Ok();
        }
        
        [Route("api/cartype/{code}")]
        public ActionResult Search(string code)
        {
            var ct = context.CarType.FirstOrDefault(cc => cc.Code == code);
            if (ct == null) return BadRequest("No car type found");
            var carType = mapper.Map<CarType, CarTypeDTO>(ct);
            return Ok(carType);
        }

        [Route("api/cartype")]
        [HttpPut]
        public ActionResult Update([FromBody] CarTypeDTO carType)
        {
            var ct = context.CarType.FirstOrDefault(c => c.Code == carType.Code);
            if (ct == null) return BadRequest("Car type not found");
            ct.Tarrif = carType.Tarrif;
            context.CarType.Update(ct);
            context.SaveChanges();
            return Ok();
        }
    }
}