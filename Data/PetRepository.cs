using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Models
{
    public class PetRepository : IPetRepository
    {
        private readonly AppDbContext appDbContext;

        public PetRepository(AppDbContext c)
        {
            appDbContext = c;
        }

        public IEnumerable<Pet> AllPets
        {
            get
            {
                return appDbContext.Pets.Include(p => p.Owner);
            }
        }

        public Pet GetByPetId(int Id)
        {
            return appDbContext.Pets.Include(p => p.Owner).FirstOrDefault(p => p.Id == Id);
        }

        public void CreatePet(Pet pet)
        {
            var owner = appDbContext.PetOwners.Find(pet.OwnerId);

            pet.Owner = owner;

            owner.Pets.Add(pet);

            //// foreach (var owner in appDbContext.PetOwners)
            // //{
            //     if (owner.Id == pet.OwnerIdNumber)
            //     {
            //         pet.Owner = owner;

            //         owner.Pets.Add(pet);
            //     }

            // //}

            appDbContext.Pets.Add(pet);

            appDbContext.SaveChanges();
        }

        public void EditPet(Pet pet)
        {
            foreach (var dbPet in appDbContext.Pets)
            {
                if (dbPet.Id == pet.Id)
                {
                    dbPet.PetName = pet.PetName;

                    dbPet.PetAge = pet.PetAge;

                    dbPet.PetType = pet.PetType;
                }
            }

            appDbContext.SaveChanges();
        }

        public void DeletePet(Pet pet)
        {
            foreach (var dbPet in appDbContext.Pets)
            {
                if (dbPet.Id == pet.Id)
                {
                    appDbContext.Pets.Remove(dbPet);
                }
            }

            appDbContext.SaveChanges();
        }

        public void AddPhoto(IFormFile photo, int petId)
        {

            byte[] fileBytes;


            using (var ms = new MemoryStream())
            {
                photo.CopyTo(ms);
                fileBytes = ms.ToArray();
                string s = Convert.ToBase64String(fileBytes);
                // act on the Base64 data
            }


            foreach (var pet in appDbContext.Pets)
            {
                if (pet.Id == petId)
                {
                    pet.UploadedFile = fileBytes;
                }
            }

            appDbContext.SaveChanges();
        }
    }
}
