using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Models
{
    public class PetOwnerRepository : IPetOwnerRepository
    {
        private readonly AppDbContext appDbContext;

        public PetOwnerRepository(AppDbContext c)
        {
            appDbContext = c;
        }

        public IEnumerable<PetOwner> AllPetOwners
        {
            get
            {
                return appDbContext.PetOwners.Include(p => p.Pets);
            }
        }

        public PetOwner GetByPetOwnerId(int Id)
        {
            return appDbContext.PetOwners.Include(p => p.Pets).FirstOrDefault(p => p.Id == Id);
        }

        public void CreatePetOwner(PetOwner owner)
        {
            appDbContext.PetOwners.Add(owner);

            appDbContext.SaveChanges();
        }

        public void EditPetOwner(PetOwner owner)
        {
            foreach (var dbOwner in appDbContext.PetOwners)
            {
                if (dbOwner.Id == owner.Id)
                {
                    dbOwner.FirstName = owner.FirstName;
                    dbOwner.LastName = owner.LastName;
                }
            }

            appDbContext.SaveChanges();
        }

        public void DeletePetOwner(PetOwner owner)
        {
            foreach (var dbOwner in appDbContext.PetOwners)
            {
                if (dbOwner.Id == owner.Id)
                { 
                    foreach(var pet in dbOwner.Pets)
                    {
                        appDbContext.Pets.Remove(pet);
                    }

                    appDbContext.PetOwners.Remove(dbOwner);
                }
            }

            appDbContext.SaveChanges();
        }
    }
}
