using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.DataAccess
{
    // store and return inmates on demand
    public class InmateStorage
    {
        static List<Inmate> _alcatraz = new List<Inmate>()
        {
            new Inmate {
                Id = 1,
                Name = "Anthony Weiner",
                Conviction = "Sending sexually explicit photos of himself to a 15-year-old girl",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Romance, Interests.Reading, Interests.Democrat },
                Services = new Dictionary<string, double>(){ {"Shiv disposal", 5.00 } }
                },
            new Inmate {
                Id = 2,
                Name = "Chaka Fattah",
                Conviction = "Convicted on 23 counts of racketeering, fraud, and other corruption charges.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Contraband, Interests.Reading, Interests.Democrat },
                Services = new Dictionary<string, double>(){ {"Laundry", 1.00 } }
                },
            new Inmate {
                Id = 3,
                Name = "Mark E. Fuller",
                Conviction = "Found guilty of domestic violence and sentenced to 24 weeks of family and domestic training and forced to resign his position.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Pruno, Interests.Gambling, Interests.Republican },
                Services = new Dictionary<string, double>(){ {"Hooch Man", 25.00 } }
            },
            new Inmate {
                Id = 4,
                Name = "J. Michael Farren",
                Conviction = "Convicted of the attempted murder of his wife.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Sports, Interests.Contraband, Interests.Republican },
                Services = new Dictionary<string, double>(){ {"Enforcer", 20.00 } }
            },
            new Inmate {
                Id = 5,
                Name = "Duke Cunningham",
                Conviction = "Pleaded guilty to charges of conspiracy to commit bribery, mail fraud, wire fraud and tax evasion",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Contraband, Interests.Pruno, Interests.Republican },
                Services = new Dictionary<string, double>(){ {"Contraband Dealer", 10.00 } }
            },
            new Inmate {
                Id = 6,
                Name = "Bill Janklow",
                Conviction = "Convicted of second-degree manslaughter for running a stop sign and killing a motorcyclist.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Gambling, Interests.Romance, Interests.Republican },
                Services = new Dictionary<string, double>(){ {"Stylist", 3.00 } }
            },
            new Inmate {
                Id = 7,
                Name = "Wade Sanders",
                Conviction = "Sentenced to 37 months in prison on one charge of possession of child pornography.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Reading, Interests.Sports, Interests.Democrat },
                Services = new Dictionary<string, double>(){ {"Librarian", 200.00 } }
            },
            new Inmate {
                Id = 8,
                Name = "Austin Murphy",
                Conviction = "Convicted of one count of voter fraud for filling out absentee ballots for members of a nursing home.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Contraband, Interests.Romance, Interests.Democrat },
                Services = new Dictionary<string, double>(){ {"Cafeteria Worker", 5.00 } }
            },
            new Inmate {
                Id = 9,
                Name = "Michael Grimm",
                Conviction = "Pleaded guilty of felony tax evasion.",
                Friends = new List<Inmate>(),
                Enemies = new List<Inmate>(),
                Interests = new List<Interests>{ Interests.Pruno, Interests.Reading, Interests.Republican },
                Services = new Dictionary<string, double>(){ {"Tattoo Artist", 15.00 } }
            }
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

        //public List<Inmate>GetAll([FromQuery] string service, string interest)
        //{
        //    // not sure what is working/broken
        //    if (service != null)
        //    {
        //        return _alcatraz.Where(inmate => inmate.Services.ContainsKey(service)).ToList();
        //    }
        //    if (interest != null)
        //    {
        //        var searchInterest = (Interests)Enum.Parse(typeof(Interests), interest);
        //        var inmates = _alcatraz.Where(inmate => inmate.Interests.Contains(searchInterest)).ToList<Inmate>();
        //        return inmates;
        //    }
        //    else 
        //    {
        //        return _alcatraz;
        //    }
        //}

        
    }
}
