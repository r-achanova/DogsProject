﻿using DogsApp.Infrastructure.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogsApp.Core.Contracts
{
    public interface IBreedService
    {
        List<Breed> GetBreeds();
        Breed GetBreedById(int breedId);
        List<Dog> GetDogsByBreed(int breedId);
    }
}
