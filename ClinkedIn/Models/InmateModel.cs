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
        public Dictionary<string, double> Interests { get; set; }
        public Services Services { get; set; }
    }
}
