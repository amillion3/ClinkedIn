using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InterestController : Controller
    {
        static List<InterestType> Interests = new List<InterestType>();

        [HttpGet]
        public ActionResult<IEnumerable<InterestType>> GetAllFavorites()
        {
            return Interests;
        }

        [HttpGet("api/interest/{name}")]
        public ActionResult<IEnumerable<InterestType>> GetSingleFavorite(string name)
        {
            var matchingInterest = 
                Interests.Where( interest => interest.Equals(name) );
            // why does this return work?
            return Ok(matchingInterest);
        }
    }
}