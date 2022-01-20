using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Models
{
    public class Pet
    {
        public int Id { get; set; }

        public string PetName { get; set; }

        public int PetAge { get; set; }

        public PetOwner Owner { get; set; }

        public int OwnerId { get; set; }

        public string PetType { get; set; }

        public byte[] UploadedFile { get; set; }
    }
}
