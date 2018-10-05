using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClinkedIn.Models;

namespace ClinkedIn.DataAccess
{
    namespace ClinkedIn.DataAccess
    {
        // store and return inmates on demand
        public class InmateStorage
        {
            static List<Inmate> _alcatraz = new List<Inmate>();

            public void Add(Inmate inmate)
            {
                // does inmate have an id? if no, find the highest id and add 1
                // if not, set the id to 1 (IE, the very first inmate)
                inmate.Id = _alcatraz.Any() ?
                    _alcatraz.Max(i => i.Id) + 1
                    : 1;
                _alcatraz.Add(inmate);
            }

            public Inmate GetById(int id)
            {
                // Find the first matching id from _alcatraz
                return _alcatraz.First(i => i.Id == id);
            }
        }
    }
}
