using System;
using System.Linq;
using AutoMapper;
using carRental.DTO;
using carRental.Models;
using Microsoft.AspNetCore.Mvc;

namespace carRental.Controllers {
    public class SharedController : Controller {
        private readonly RentalDbContext context;
        private readonly IMapper mapper;
        public SharedController (RentalDbContext context, IMapper mapper) {
            this.mapper = mapper;
            this.context = context;
        }

        [Route ("api/common/colors")]
        public ActionResult GetColors () {
            var colors = context.Color.Where (c => c.Code != null).ToList ();
            if (colors == null) return BadRequest ("Could not fetch colors");
            return Ok (colors);
        }

        [Route ("api/common/agencies")]
        public ActionResult GetAgencies () {
            var agencies = context.RentalAgency.Where (c => c.Code != null).ToList ();
            if (agencies == null) return BadRequest ("Could not fetch agencies");
            return Ok (agencies);
        }

        [Route ("/api/common/cartypes")]
        public ActionResult GetCarTypes () {
            var cartypes = context.CarType.Where (c => c.Code != null);
            if (cartypes == null) return BadRequest ("Could not fetch car types");
            return Ok (cartypes);
        }

        [Route ("/api/login")]
        [HttpPost]
        public ActionResult Loggin ([FromBody] Login user) {
            var emp = context.Employee.FirstOrDefault (e => (e.StaffNumber.ToString () == user.Username || e.IdNumber.ToString () == user.Username) && e.Password == user.password);
            if (emp == null) return BadRequest ("Incorrect username or password");
            return Ok (emp);
        }

        [Route ("/api/change")]
        [HttpPost]
        public ActionResult ChangePassword ([FromBody] ChangePassword password) {
            var emp = context.Employee.FirstOrDefault (e => (e.StaffNumber.ToString () == password.StaffNumber));
            if (emp == null) return BadRequest ("Unable to change password");
            if (emp.Password == password.OldPassWord) {
                emp.Password = password.NewPassword;
                context.Employee.Update (emp);
                context.SaveChanges ();
            } else return BadRequest ("Your current password is incorrect");
            return Ok ();
        }

        [Route ("/api/validate")]
        [HttpPost]
        public ActionResult ValidateDate ([FromBody] DateDTO date) {
            var client = Convert.ToDateTime (date.Date);
            var today = new DateTime ();
            var sum = today.Year - client.Year;

            if (sum < 21) return BadRequest ("Client must be 21 or older  " + sum.ToString ());
            return Ok (today.Year - client.Year);
        }

        [Route ("/api/client")]
        [HttpPost]
        public ActionResult AddClient ([FromBody] ClientDTO client) {
            var c = context.Client.FirstOrDefault(cc => cc.ClientNumber.ToString() == client.ClientNumber || cc.IdNumber == client.IdNumber);
            if (c != null) return BadRequest("Client already exist");
            context.Client.Add (mapper.Map<ClientDTO, Client>(client));
            context.SaveChanges();
            return Ok();
        }

        [Route("/api/rent")]
        [HttpPost]
        public ActionResult RentACar([FromBody] RentalDTO rental)
        {
            var car = context.Car.FirstOrDefault(c => c.RegistrationNumber == rental.CarRegistrationCode);
            if (car == null) return BadRequest("Car no longer available");
            var quote = mapper.Map<RentalDTO, Rental>(rental);
            var carType = context.CarType.FirstOrDefault(c => c.Code == car.CarTypeCode);
            var days = (Convert.ToDateTime(rental.ToDate) - Convert.ToDateTime(rental.FromDate)).Days;
            if (days == 0) return BadRequest("Pickup & return dates cannot be the same");
            if (days < 0) return BadRequest("Return date cannot be before pickup date");
            quote.Amount = days * carType.Tarrif;
            quote.CarRegistrationCode = rental.CarRegistrationCode;
            car.Available = false;
            context.Rental.Add(quote);
            context.SaveChanges();
            return Ok();
        }

        [Route("/api/delete/{clientCode}")]
        [HttpPost]
        public ActionResult DeleteClient(long clientCode)
        {
            var client = context.Client.FirstOrDefault(c => c.ClientNumber == clientCode);
            if (client == null) return Ok("Client was no longer available");
            context.Remove(client);
            context.SaveChanges();
            return Ok("Client removed from our DB");
        }

        [Route("/api/pickup")]
        [HttpPost]
        public ActionResult Pickup([FromBody] PickupDTO pickup)
        {
            var client = context.Client.FirstOrDefault(c => c.ClientNumber == pickup.ClientNumber);
            if (client == null) return BadRequest("Client not found");
            var rental = context.Rental.FirstOrDefault(c => c.ClientNumber == pickup.ClientNumber);
            if (rental == null) return BadRequest("Client does not have a car to pick up");
            var car = context.Car.FirstOrDefault(c => c.RegistrationNumber == rental.CarRegistrationCode);
            if (car == null) return BadRequest("Car associated could not be found");
            var cartype = context.CarType.FirstOrDefault(c => c.Code == car.CarTypeCode);
            if (cartype == null) return BadRequest("Cartype associated with this client seem to be lost");
            var clientAmount = (rental.ToDate - rental.FromDate).Days * cartype.Tarrif;
            if (clientAmount == rental.Amount) return BadRequest("Client still needs to pay deposit");
            context.Pickup.Add(new PickUp {ClientNumber = pickup.ClientNumber, Date = Convert.ToDateTime(pickup.Date)});
            context.SaveChanges();
            return Ok();
        }

        [Route("/api/pay")]
        [HttpPost]
        public ActionResult Pay([FromBody] PaymentDTO payment)
        {
            var client = context.Client.FirstOrDefault(c => c.ClientNumber == payment.ClientNumber);
            if (client == null) return BadRequest("Client not found");
            var rental = context.Rental.FirstOrDefault(c => c.ClientNumber == payment.ClientNumber);
            if (rental == null) return BadRequest("Client does not have to pay anything");
            rental.Amount -= payment.amount;
            this.context.Payment.Add(new Payment {ClientNumber = client.ClientNumber, amount = payment.amount, Date = new DateTime()});
            context.SaveChanges();
            return Ok();
        }

        [Route("/api/client/{clientNumber}")]
        public ActionResult FindClient(long clientNumber)
        {
            var client = context.Client.FirstOrDefault(c => c.ClientNumber == clientNumber);
            if (client == null) return BadRequest("Client could not be found");
            return Ok();
        }

        [Route("/api/re")]
        [HttpPost]
        public ActionResult FindClient([FromBody] ReceiveDTO r)
        {
            bool a = false;
            var rental = context.Rental.FirstOrDefault(c => c.ClientNumber == r.ClientNumber);
            if (rental == null) return BadRequest("Unable to find client's pick up");
            var car = context.Car.FirstOrDefault(c => c.RegistrationNumber == rental.CarRegistrationCode);
            if (car == null) return BadRequest("Car associated could not be found");
            var cartype = context.CarType.FirstOrDefault(c => c.Code == car.CarTypeCode);
            if (cartype == null) return BadRequest("Cartype associated with this client seem to be lost");
            var rdate = Convert.ToDateTime(r.Date);

            if ((rental.ToDate - rental.FromDate).Days < (rdate - rental.FromDate).Days)
            {
               rental.Amount *= 0.1;
               a = true;

            }

            car.Available = true;

            var payments = context.Payment.Where(p => p.ClientNumber == r.ClientNumber);
            var invoice = new InvoiceDTO{};
            invoice.Amount = rental.Amount;
            invoice.AdditionalFees = a;
            invoice.CarReg = rental.CarRegistrationCode;
            invoice.ClientNumber = r.ClientNumber;
            invoice.Deposit = ((rental.ToDate - rental.FromDate).Days * cartype.Tarrif) * 0.5;
            context.SaveChanges();

            return Ok(invoice);
        }
    }
}