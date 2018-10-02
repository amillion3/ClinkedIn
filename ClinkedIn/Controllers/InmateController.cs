using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                new Inmate {Conviction = "Sending sexually explicit photos of himself to a 15-year-old girl", Interests = InterestModel.Romance, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 1, Name = "Anthony Weiner"},
                new Inmate {Conviction = "Convicted on 23 counts of racketeering, fraud, and other corruption charges.", Interests = InterestModel.Pruno, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 2, Name = "Chaka Fattah"},
                new Inmate {Conviction = "Found guilty of domestic violence and sentenced to 24 weeks of family and domestic training and forced to resign his position. ", Interests = InterestModel.Sports, Services =new ServiceModel(), Friends = new List<Inmate>, ID = 3, Name = "Mark E. Fuller"},
                new Inmate {Conviction = "Convicted of the attempted murder of his wife.", Interests = InterestModel.Reading, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 4, Name = "J. Michael Farren"},
                new Inmate {Conviction = "Pleaded guilty to charges of conspiracy to commit bribery, mail fraud, wire fraud and tax evasion", Interests = InterestModel.Contraband, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 5, Name = "Duke Cunningham"},
                new Inmate {Conviction = "Convicted of second-degree manslaughter for running a stop sign and killing a motorcyclist.", Interests = InterestModel.Gambling, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 6, Name = "Bill Janklow"},
                new Inmate {Conviction = "Sentenced to 37 months in prison on one charge of possession of child pornography.", Interests = InterestModel.Republican, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 7, Name = "Wade Sanders"},
                new Inmate {Conviction = "Convicted of one count of voter fraud for filling out absentee ballots for members of a nursing home.", Interests = InterestModel.Democrat, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 8, Name = "Austin Murphy"},
                new Inmate {Conviction = "Pleaded guilty of felony tax evasion.", Interests = InterestModel.Reading, Services = new ServiceModel(), Friends = new List<Inmate>, ID = 9, Name = "Michael Grimm"}
            }
        }

        [HttpGet]
        public ActionResult<List<Inmate>> GetAll()
        {
            return Inmates;
        }

        [HttpGet("{id}")]
        public ActionResult<List<Inmate>> GetInmateById(int id)
        {
            var InmateById = Inmates.Where(inmate => inmate.id == inmate.Id);
            return Ok();
        }
    }
}