using Microsoft.AspNetCore.Mvc;
using PetTracking.Models;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Http;
using Microsoft.Web.Helpers;

namespace PetTracking.Controllers
{
    public class PetController : Controller
    {

        private readonly IPetRepository petRepository;
        private readonly IPetOwnerRepository petOwnerRepository;

        public PetController(IPetRepository pr, IPetOwnerRepository or)
        {
            petRepository = pr;

            petOwnerRepository = or;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PetList()
        {
            return View(petRepository.AllPets);
        }


        [HttpPost]
        public IActionResult PetList(string search)
        {
            if (!string.IsNullOrEmpty(search))
                return View(petRepository.AllPets.Where(p => (p.PetName.ToLower() + " " + p.PetName.ToLower()).Contains(search.ToLower())));

            return View(petRepository.AllPets);
        }

        public IActionResult AddPet()
        {
            return View(petOwnerRepository.AllPetOwners);
        }


        [HttpPost]
        public IActionResult AddPet(Pet pet)
        {
            petRepository.CreatePet(pet);

            return RedirectToAction("PetList");
        }


        public IActionResult PetDetails(int id)
        {
            return View(petRepository.GetByPetId(id));
        }

        public IActionResult EditPet(int id)
        {
            return View(petRepository.GetByPetId(id));
        }

        [HttpPost]
        public IActionResult EditPet(Pet pet)
        {
            petRepository.EditPet(pet);

            return RedirectToAction("PetDetails", pet);
        }

        public IActionResult DeletePet(int id)
        {
            return View(petRepository.GetByPetId(id));
        }

        [HttpPost]
        public IActionResult DeletePet(Pet pet)
        {
            petRepository.DeletePet(pet);

            return RedirectToAction("PetList");
        }


        public IActionResult AddPhoto(int id)
        {
            return View(petRepository.GetByPetId(id));
        }

        [HttpPost]
        public IActionResult AddPhoto(IFormFile photo, int petId)
        {
            petRepository.AddPhoto(photo, petId);

            return RedirectToAction("PetList");
        }




        //[HttpPost]
        //public async Task<ActionResult> Register(Pet model)
        //{

        //}

    }
}
