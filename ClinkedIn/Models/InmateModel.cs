using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class InmateModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Conviction { get; set; }
        public List<string> Friends { get; set; }
        public List<string> Interests { get; set; }
        public List<string> services { get; set; }
    }
}
