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
    }

    [HttpGet("inmates/{id}")]
    public ActionResult<List<Inmate>> GetInmateById(int id)
    {
      var inmates = _alcatraz.GetAllFromStorage();
      var InmateById = inmates.Where(inmate => inmate.Id == id);
      return Ok(InmateById);
    }

    [HttpPut("inmates/{id}")]
    public ActionResult AddInterestToInmate(int id, [FromQuery]Interests interest)
    {
      var inmates = _alcatraz.GetAllFromStorage();
      var InmateById = inmates.Where(inmate => inmate.Id == id);

      if (InmateById == null)
      {
        return NotFound();
      }
      //Verify the input interest is not already an interest of the inmate
      else if (!InmateById.ElementAt(0).Interests.Contains(interest))
      {
        InmateById.ElementAt(0).Interests.Add(interest);
        Console.WriteLine(InmateById);
        return Ok();
      }
      else
      {
        return BadRequest();
      }
    }

    [HttpPut("inmates/AddAFriend/{id}/{friendId}")]
    public ActionResult AddAFriend(int id, int friendId)
    {
      var inmates = _alcatraz.GetAllFromStorage();
      var userInmate = inmates.First(user => user.Id == id);
      var desiredFriend = inmates.First(desired => desired.Id == friendId);

      if (userInmate == null)
      {
        return BadRequest();
      }
      else if (!userInmate.Friends.Contains(desiredFriend))
      {
        userInmate.Friends.Add(desiredFriend);
        desiredFriend.Friends.Add(userInmate);
        return Ok();
      }
      else
      {
        return BadRequest();
      }
    }

    [HttpPut("inmates/RemoveAFriend/{id}/{friendId}")]
    public ActionResult RemoveAFriend(int id, int friendId)
    {
      var inmates = _alcatraz.GetAllFromStorage();
      var userInmate = inmates.First(user => user.Id == id);
      var desiredFriend = inmates.First(desired => desired.Id == friendId);

      if (userInmate == null)
      {
        return BadRequest();
      }
      else if (userInmate.Friends.Contains(desiredFriend))
      {
        userInmate.Friends.Remove(desiredFriend);
        desiredFriend.Friends.Remove(userInmate);
        return Ok();
      }
      else
      {
        return BadRequest();
      }
    }
  }
}