using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Models
{
    public interface IPetOwnerRepository
    {
        IEnumerable<PetOwner> AllPetOwners { get; }

        PetOwner GetByPetOwnerId(int Id);

        void CreatePetOwner(PetOwner owner);

        void EditPetOwner(PetOwner owner);
        void DeletePetOwner(PetOwner owner);
    }
}
