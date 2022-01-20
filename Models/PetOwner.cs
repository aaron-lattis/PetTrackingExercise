using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Models
{
    public class PetOwner
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Pet> Pets { get; set; } = new List<Pet>();
    }
}
