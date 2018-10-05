using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using ClinkedIn.DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;

namespace ClinkedIn.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class InmateController : Controller
  {
    //[HttpGet("inmates")]
    //public ActionResult<List<Inmate>> GetAll([FromQuery] string service, string interest)
    //{
    //  // not sure what is working/broken
    //  if (service != null)
    //  {
    //    return _alcatraz.GetAllFromStorage.Where(inmate => inmate.Services.ContainsKey(service)).ToList();
    //  }
    //  if (interest != null)
    //  {
    //    var searchInterest = (Interests)Enum.Parse(typeof(Interests), interest);
    //    var inmates = Inmates.Where(inmate => inmate.Interests.Contains(searchInterest)).ToList<Inmate>();
    //    return inmates;
    //  }
    //  else
    //  {
    //    return Inmates;
    //  }
    //}

    //[HttpGet("inmates/{id}")]
    //public ActionResult<List<Inmate>> GetInmateById(int id)
    //{
    //  var InmateById = Inmates.Where(inmate => inmate.Id == id);
    //  return Ok(InmateById);
    //}

    // .../api/inmate/{id}?interest={interest}
    // .../api/inmate/5?interest=reading

    //[HttpPut("inmates/{id}")]
    //public ActionResult AddInterestToInmate(int id, [FromQuery]Interests interest)
    //{
    //  var InmateById = Inmates.Find(inmate => inmate.Id == id);

    //  if (InmateById == null)
    //  {
    //    return NotFound();
    //  }
    //  // Verify the input interest is not already an interest of the inmate
    //  else if (!InmateById.Interests.Contains(interest))
    //  {
    //    InmateById.Interests.Add(interest);
    //    Console.WriteLine(InmateById);
    //    return Ok();
    //  }
    //  else
    //  {
    //    return BadRequest();
    //  }
    //}

    // storage
    private readonly InmateStorage _alcatraz;
    public InmateController()
    {
      _alcatraz = new InmateStorage();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Inmate>> GetAll()
    {
      var storage = new InmateStorage();
      var inmates = storage.GetAllFromStorage();
      return Ok(inmates);
      // inmates is from the InmateStorage, our 'temp database'
    }

    [HttpPost]
    public void AddAnInmate(Inmate inmate)
    {
      var storage = new InmateStorage();
      storage.AddNewInmateInStorage(inmate);
    }

    [HttpGet("inmates")]
    public ActionResult<List<Inmate>> GetAllInmates([FromQuery] string service, string interest)
    {
        var inmates = _alcatraz.GetAllFromStorage();
        if (service != null)
      {
        return inmates.Where(inmate => inmate.Services.ContainsKey(service)).ToList();
      }
      if (interest != null)
      {
        var searchInterest = (Interests)Enum.Parse(typeof(Interests), interest);
        var interestingInmates = inmates.Where(inmate => inmate.Interests.Contains(searchInterest)).ToList<Inmate>();
        return interestingInmates;
      }
      else
      {
        return inmates.ToList();
      }
<<<<<<< HEAD
    }

    [HttpPost]
    public void AddAFriend(int id, Inmate inmate)
    {
      var inmates = _alcatraz.GetAllFromStorage();
      var userInmate = inmates.First(user => user.Id == id);

      userInmate.Friends.Add(inmate);
=======
>>>>>>> master
    }
  }
}