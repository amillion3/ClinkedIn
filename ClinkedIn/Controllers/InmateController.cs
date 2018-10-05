using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InmateController : Controller
    {
        static List<Inmate> Inmates;

        static InmateController()
        {
            Inmates = new List<Inmate>
            {
                new Inmate {Id = 1, Name = "Anthony Weiner", Conviction = "Sending sexually explicit photos of himself to a 15-year-old girl", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 2, Name = "Chaka Fattah", Conviction = "Convicted on 23 counts of racketeering, fraud, and other corruption charges.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 3, Name = "Mark E. Fuller", Conviction = "Found guilty of domestic violence and sentenced to 24 weeks of family and domestic training and forced to resign his position.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 4, Name = "J. Michael Farren", Conviction = "Convicted of the attempted murder of his wife.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 5, Name = "Duke Cunningham", Conviction = "Pleaded guilty to charges of conspiracy to commit bribery, mail fraud, wire fraud and tax evasion", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 6, Name = "Bill Janklow", Conviction = "Convicted of second-degree manslaughter for running a stop sign and killing a motorcyclist.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 7, Name = "Wade Sanders", Conviction = "Sentenced to 37 months in prison on one charge of possession of child pornography.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 8, Name = "Austin Murphy", Conviction = "Convicted of one count of voter fraud for filling out absentee ballots for members of a nursing home.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
                new Inmate {Id = 9, Name = "Michael Grimm", Conviction = "Pleaded guilty of felony tax evasion.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()}
            };

            Inmates[0].Services.Add("Shiv disposal", 5.00);
            Inmates[1].Services.Add("Enforcer", 20.00);
            Inmates[2].Services.Add("Contraband Dealer", 10.00);
            Inmates[3].Services.Add("Stylist", 3.00);
            Inmates[4].Services.Add("Librarian", 2.00);
            Inmates[5].Services.Add("Cafeteria Worker", 4.00);
            Inmates[6].Services.Add("Laundry", 1.00);
            Inmates[7].Services.Add("Tattoo Artist", 8.00);
            Inmates[8].Services.Add("Hooch Man", 9.00);

            Inmates[0].Interests.Add(Interests.Romance);
            Inmates[0].Interests.Add(Interests.Reading);
            Inmates[0].Interests.Add(Interests.Democrat);
            Inmates[1].Interests.Add(Interests.Reading);
            Inmates[1].Interests.Add(Interests.Contraband);
            Inmates[1].Interests.Add(Interests.Democrat);
            Inmates[2].Interests.Add(Interests.Pruno);
            Inmates[2].Interests.Add(Interests.Gambling);
            Inmates[2].Interests.Add(Interests.Republican);
            Inmates[3].Interests.Add(Interests.Sports);
            Inmates[3].Interests.Add(Interests.Contraband);
            Inmates[3].Interests.Add(Interests.Republican);
            Inmates[4].Interests.Add(Interests.Contraband);
            Inmates[4].Interests.Add(Interests.Pruno);
            Inmates[4].Interests.Add(Interests.Republican);
            Inmates[5].Interests.Add(Interests.Gambling);
            Inmates[5].Interests.Add(Interests.Romance);
            Inmates[5].Interests.Add(Interests.Republican);
            Inmates[6].Interests.Add(Interests.Reading);
            Inmates[6].Interests.Add(Interests.Sports);
            Inmates[6].Interests.Add(Interests.Democrat);
            Inmates[7].Interests.Add(Interests.Contraband);
            Inmates[7].Interests.Add(Interests.Romance);
            Inmates[7].Interests.Add(Interests.Democrat);
            Inmates[8].Interests.Add(Interests.Reading);
            Inmates[8].Interests.Add(Interests.Pruno);
            Inmates[8].Interests.Add(Interests.Republican);
        }



        [HttpGet("inmates")]
        public ActionResult<List<Inmate>> GetAll([FromQuery] string service, string interest)
        {
            if (service != null)
            {
                return Inmates.Where(inmate => inmate.Services.ContainsKey(service)).ToList();
            }
            if (interest != null)
            {
                var searchInterest = (Interests)Enum.Parse(typeof(Interests), interest);
                var inmates = Inmates.Where(inmate => inmate.Interests.Contains(searchInterest)).ToList<Inmate>();
                return inmates;
            }
            else 
            {
                return Inmates;
            }

        }

        [HttpGet("inmates/{id}")]
        public ActionResult<List<Inmate>> GetInmateById(int id)
        {
            var InmateById = Inmates.Where(inmate => inmate.Id == id);
            return Ok(InmateById);
        }

        // .../api/inmate/{id}?interest={interest}
        // .../api/inmate/5?interest=reading
        [HttpPut("inmates/{id}")]
        public ActionResult AddInterestToInmate(int id, [FromQuery]Interests interest)
        {
            var InmateById = Inmates.Find(inmate => inmate.Id == id);

            if (InmateById == null)
            {
                return NotFound();
            }
            // Verify the input interest is not already an interest of the inmate
            else if (!InmateById.Interests.Contains(interest))
            {
                InmateById.Interests.Add(interest);
                Console.WriteLine(InmateById);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("")]
    }
}