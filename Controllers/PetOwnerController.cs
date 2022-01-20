using Microsoft.AspNetCore.Mvc;
using PetTracking.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetTracking.Controllers
{
    public class PetOwnerController : Controller
    {

        private readonly IPetOwnerRepository petOwnerRepository;

        public PetOwnerController(IPetOwnerRepository r)
        {
            petOwnerRepository = r;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult OwnerList()
        {
            return View(petOwnerRepository.AllPetOwners);
        }

        [HttpPost]
        public IActionResult OwnerList(int order, int first, int last, string search)
        {
            
            //if (order == 1)
            //{
            //    if (first > last)
            //        return View(petOwnerRepository.AllPetOwners.OrderBy(p => p.Id));

            //    else
            //        return View(petOwnerRepository.AllPetOwners.OrderByDescending(p => p.Id));
            //}
            //else if (order == 2)
            //{


            //    if (first < last)
            //        return View(petOwnerRepository.AllPetOwners.OrderByDescending(p => p.Pets.Count));

            //    else
            //        return View(petOwnerRepository.AllPetOwners.OrderBy(p => p.Pets.Count));


            //}

            if(!string.IsNullOrEmpty(search))
                return View(petOwnerRepository.AllPetOwners.Where(p => (p.FirstName.ToLower() + " " + p.LastName.ToLower()).Contains(search.ToLower())));

            return View(petOwnerRepository.AllPetOwners);
        }



        public IActionResult OwnerDetails(int id)
        {
            return View(petOwnerRepository.GetByPetOwnerId(id));
        }

        public IActionResult AddPetOwner()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPetOwner(PetOwner owner)
        {
            petOwnerRepository.CreatePetOwner(owner);

            return RedirectToAction("OwnerList");
        }

        public IActionResult EditOwner(int id)
        {
            return View(petOwnerRepository.GetByPetOwnerId(id));
        }

        [HttpPost]
        public IActionResult EditOwner(PetOwner owner)
        {
            petOwnerRepository.EditPetOwner(owner);

            return RedirectToAction("OwnerDetails", owner);
        }

        public IActionResult DeleteOwner(int id)
        {
            return View(petOwnerRepository.GetByPetOwnerId(id));
        }


        [HttpPost]
        public IActionResult DeleteOwner(PetOwner owner)
        {
            petOwnerRepository.DeletePetOwner(owner);

            return RedirectToAction("OwnerList");
        }

    }
}
