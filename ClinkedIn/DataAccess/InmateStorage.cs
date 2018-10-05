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
        public void alcatraz()
        {
            List<Inmate> Inmates = new List<Inmate>()
            {
            new Inmate {Id = 1, Name = "anthony weiner", Conviction = "sending sexually explicit photos of himself to a 15-year-old girl", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>{Interests.Contraband }, Services = new Dictionary<string, double>()},
            new Inmate {Id = 2, Name = "chaka fattah", Conviction = "convicted on 23 counts of racketeering, fraud, and other corruption charges.", Friends = new List<Inmate>(), Enemies = new List<Inmate>(), Interests = new List<Interests>{Interests.Reading }, Services = new Dictionary<string, double>()},
            //new inmate {id = 3, name = "mark e. fuller", conviction = "found guilty of domestic violence and sentenced to 24 weeks of family and domestic training and forced to resign his position.", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()},
            //new inmate {id = 4, name = "j. michael farren", conviction = "convicted of the attempted murder of his wife.", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()},
            //new inmate {id = 5, name = "duke cunningham", conviction = "pleaded guilty to charges of conspiracy to commit bribery, mail fraud, wire fraud and tax evasion", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()},
            //new inmate {id = 6, name = "bill janklow", conviction = "convicted of second-degree manslaughter for running a stop sign and killing a motorcyclist.", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()},
            //new inmate {id = 7, name = "wade sanders", conviction = "sentenced to 37 months in prison on one charge of possession of child pornography.", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()},
            //new inmate {id = 8, name = "austin murphy", conviction = "convicted of one count of voter fraud for filling out absentee ballots for members of a nursing home.", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()},
            //new inmate {id = 9, name = "michael grimm", conviction = "pleaded guilty of felony tax evasion.", friends = new list<inmate>(), enemies = new list<inmate>(), interests = new list<interests>(), services = new dictionary<string, double>()}
            };
            Inmates[0].Services.Add("Shiv disposal", 5.00);
            Inmates[1].Services.Add("Enforcer", 20.00);
            //Inmates[2].Services.Add("Contraband Dealer", 10.00);
            //Inmates[3].Services.Add("Stylist", 3.00);
            //Inmates[4].Services.Add("Librarian", 2.00);
            //Inmates[5].Services.Add("Cafeteria Worker", 4.00);
            //Inmates[6].Services.Add("Laundry", 1.00);
            //Inmates[7].Services.Add("Tattoo Artist", 8.00);
            //Inmates[8].Services.Add("Hooch Man", 9.00);
        }




            public void AddNewInmateInStorage(Inmate inmate)
            {
                // does inmate have an id? if no, find the highest id and add 1
                // if not, set the id to 1 (IE, the very first inmate)
                inmate.Id = alcatraz.Inmates.Any() ?
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
