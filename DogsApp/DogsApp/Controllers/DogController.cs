﻿
using DogsApp.Core.Contracts;
using DogsApp.Infrastructure.Data;
using DogsApp.Infrastructure.Data.Domain;
using DogsApp.Models.Dog;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace DogsApp.Controllers
{
    public class DogController : Controller
    {
        private readonly IDogService _dogService;

        public DogController(IDogService dogsService)
        {
            this._dogService = dogsService;
        }

        public IActionResult Create()
        {
             return this.View();
           
        }

        [HttpPost]
        public IActionResult Create(DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {

              var created=  _dogService.Create(bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Picture);
                if (created)
                {
                    return this.RedirectToAction("Success");
                }
            }
          
            return this.View();
        }
        public IActionResult Edit(int id)
        {
            
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogEditViewModel dog = new DogEditViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture=item.Picture
            };
            return View(dog);
        }

        [HttpPost]
        public IActionResult Edit(int id, DogCreateViewModel bindingModel)
        {
            if (ModelState.IsValid)
            {
                var updated = _dogService.UpdateDog(id, bindingModel.Name, bindingModel.Age, bindingModel.Breed, bindingModel.Picture);
                if (updated)
                {
                    return this.RedirectToAction("Index");
                }
                
            }
            return View(bindingModel);

        }
        

        public IActionResult Delete(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _dogService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Index", "Dogs");
            }
            else
            {
                return View();
            }
           
        }
            public IActionResult Success()
        {
            return this.View();

        }

        public IActionResult Index(string searchStringBreed, string searchStringName)
        {

            List<DogAllViewModel> dogs = _dogService.GetDogs( searchStringBreed,  searchStringName)
                .Select(dogFromDb=> new DogAllViewModel
                {
                    Id=dogFromDb.Id,
                    Name = dogFromDb.Name,
                    Age= dogFromDb.Age,
                    Breed=dogFromDb.Breed,
                    Picture=dogFromDb.Picture
                }).ToList();
           
            return this.View(dogs);
        }

        public IActionResult Details(int id)
        {
            Dog item = _dogService.GetDogById(id);
            if (item == null)
            {
                return NotFound();
            }
            DogDetailsViewModel dog = new DogDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                Age = item.Age,
                Breed = item.Breed,
                Picture = item.Picture
            };
            return View(dog);
        }
        
        
    }
}
