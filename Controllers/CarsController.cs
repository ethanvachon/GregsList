using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GregsList.db;
using GregsList.Models;

namespace GregsList.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CarsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Car>> Get()
    {
      try
      {
        return Ok(FAKEDB.Cars);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Car> Get(string id)
    {
      try
      {
        Car carToReturn = FAKEDB.Cars.Find(c => c.Id == id);
        return Ok(carToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Car> Create([FromBody] Car newCar)
    {
      try
      {
        FAKEDB.Cars.Add(newCar);
        return Ok(newCar);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Car> Edit([FromBody] Car editCar, string id)
    {
      try
      {
        Car currentCar = FAKEDB.Cars.Find(c => c.Id == id);
        if (editCar.Make != null)
        {
          currentCar.Make = editCar.Make;
        }
        if (editCar.Model != null)
        {
          currentCar.Model = editCar.Model;
        }
        if (editCar.Year != null)
        {
          currentCar.Year = editCar.Year;
        }
        if (editCar.Price != null)
        {
          currentCar.Price = editCar.Price;
        }
        if (editCar.Description != null)
        {
          currentCar.Description = editCar.Description;
        }
        if (editCar.ImgUrl != null)
        {
          currentCar.ImgUrl = editCar.ImgUrl;
        }
        return currentCar;
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> RemoveCar(string id)
    {
      try
      {
        Car carToRemove = FAKEDB.Cars.Find(c => c.Id == id);
        if (FAKEDB.Cars.Remove(carToRemove))
        {
          return Ok("Car Removed");
        }
        throw new System.Exception("invalid id");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}