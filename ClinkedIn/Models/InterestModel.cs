using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ClinkedIn.Models
{
    public class InterestModel
    {
        public InterestType Type { get; set; }
    }

    public enum InterestType
    {
        Reading,
        Romance,
        Pruno,
        Sports,
        Contraband,
        Gambling,
        Republican,
        Democrat,
    }
}
