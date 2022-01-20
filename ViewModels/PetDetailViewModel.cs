using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.ViewModels
{
    public class PetDetailViewModel
    {

        public string Name { get; set; }

        public int Age { get; set; }

        public string Type { get; set; }

        public int Id { get; set; }

        public int OwnerId { get; set; }

        public string OwnerFullName { get; set; }

    }
}
