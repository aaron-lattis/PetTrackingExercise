using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Models
{
    public interface IPetRepository
    {
        IEnumerable<Pet> AllPets { get; }

        Pet GetByPetId(int Id);
        
        void CreatePet(Pet pet);
        
        void EditPet(Pet pet);

        void DeletePet(Pet pet);

        void AddPhoto(IFormFile photo, int petId);
    }
}
