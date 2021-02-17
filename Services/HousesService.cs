using System.Collections.Generic;
using System;
using GregsList.db;
using GregsList.Models;

namespace GregsList.Services
{
  public class HousesService
  {
    public IEnumerable<House> Get()
    {
      return FAKEDB.Houses;
    }

    public House Get(string id)
    {
      House houseToReturn = FAKEDB.Houses.Find(c => c.Id == id);
      return houseToReturn;
    }

    public House Create(House newHouse)
    {
      FAKEDB.Houses.Add(newHouse);
      return newHouse;
    }

    public House Edit(House newHouse)
    {
      House house = FAKEDB.Houses.Find(c => c.Id == newHouse.Id);
      if (house == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Houses.Remove(house);
      FAKEDB.Houses.Add(newHouse);
      return newHouse;
    }

    public string Delete(string id)
    {
      House houseToRemove = FAKEDB.Houses.Find(c => c.Id == id);
      if (FAKEDB.Houses.Remove(houseToRemove))
      {
        return "House Removed";
      }
      throw new System.Exception("invalid id");
    }
  }
}