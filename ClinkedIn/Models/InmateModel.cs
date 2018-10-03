using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinkedIn.Models
{
    public class Inmate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Conviction { get; set; }
        public List<Inmate> Friends { get; set; }
        public List<Inmate> Enemies { get; set; }
        public List<Interests> Interests { get; set; }
        public Dictionary<string, double> Services { get; set;} = new Dictionary<string, double>();
    }

    public enum Interests
    {
        Reading, 
        Romance,
        Pruno,
        Sports,
        Contraband,
        Gambling,
        Republican,
        Democrat
    }
}
