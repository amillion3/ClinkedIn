using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

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
                new Inmate {Id = 9, Name = "Michael Grimm", Conviction = "Pleaded guilty of felony tax evasion.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Services = new Dictionary<string, double>()}
            };
        }

        [HttpGet]
        public ActionResult<List<Inmate>> GetAll()
        {
            return Inmates;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Inmate>> GetInmateById(int id)
        {
            var InmateById = Inmates.Where(inmate => inmate.Id == id);
            return Ok(InmateById);
        }

        // .../api/inmate/5?interest=reading
        [HttpPut("{id}")]
        public ActionResult AddInterestToInmate(int id, [FromQuery]Interests interest)
        {
            var InmateById = Inmates.Find(inmate => inmate.Id == id);

            if (InmateById == null)
            {
                return NotFound();
            }
            // if inmate's interest is a *new* interest
            else if (!InmateById.Interests.Contains(interest))
            {
                InmateById.Interests.Append(interest);
                return Ok();
            } 
            else
            {
                return BadRequest();
            }
        }
    }
}