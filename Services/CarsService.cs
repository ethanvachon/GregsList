using System.Collections.Generic;
using System;
using GregsList.db;
using GregsList.Models;

namespace GregsList.Services
{
  public class CarsService
  {
    public IEnumerable<Car> Get()
    {
      return FAKEDB.Cars;
    }

    public Car Get(string id)
    {
      Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
      return carToReturn;
    }

    public Car Create(Car newCar)
    {
      FAKEDB.Cars.Add(newCar);
      return newCar;
    }

    public Car Edit(Car newCar)
    {
      Car car = FAKEDB.Cars.Find(c => c.Id == newCar.Id);
      if (car == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Cars.Remove(car);
      FAKEDB.Cars.Add(newCar);
      return newCar;
    }

    public string Delete(string id)
    {
      Car carToRemove = FAKEDB.Cars.Find(c => c.Id == id);
      if (FAKEDB.Cars.Remove(carToRemove))
      {
        return "Car Removed";
      }
      throw new System.Exception("invalid id");
    }
  }
}