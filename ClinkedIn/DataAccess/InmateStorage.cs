using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    // store and return inmates on demand
    public class InmateStorage
    {
        static List<Inmate> _alcatraz = new List<Inmate>()
        {
            new Inmate {Id = 1, Name = "Anthony Weiner", Conviction = "Sending sexually explicit photos of himself to a 15-year-old girl", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
            new Inmate {Id = 2, Name = "Chaka Fattah", Conviction = "Convicted on 23 counts of racketeering, fraud, and other corruption charges.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>(), Services = new Dictionary<string, double>()},
        };

        public void AddNewInmateInStorage(Inmate inmate)
        {
            // does inmate have an id? if no, find the highest id and add 1
            // if not, set the id to 1 (IE, the very first inmate)
            inmate.Id = _alcatraz.Any() ?
                _alcatraz.Max(i => i.Id) + 1
                : 1;
            _alcatraz.Add(inmate);
            Console.WriteLine(inmate);
        }

        public IEnumerable<Inmate> GetAllFromStorage()
        {
            return _alcatraz;
        }

        public Inmate GetById(int id)
        {
            // Find the first matching id from _alcatraz
            return _alcatraz.First(i => i.Id == id);
        }
    }
}
