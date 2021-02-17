using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GregsList.db;
using GregsList.Models;

namespace GregsList.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(FAKEDB.Houses);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<House> Get(string id)
    {
      try
      {
        House houseToReturn = FAKEDB.Houses.Find(c => c.Id == id);
        return Ok(houseToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<House> Create([FromBody] House newHouse)
    {
      try
      {
        FAKEDB.Houses.Add(newHouse);
        return Ok(newHouse);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<House> Edit([FromBody] House editHouse, string id)
    {
      try
      {
        House currentHouse = FAKEDB.Houses.Find(c => c.Id == id);
        if (editHouse.Bedrooms != null)
        {
          currentHouse.Bedrooms = editHouse.Bedrooms;
        }
        if (editHouse.Bathrooms != null)
        {
          currentHouse.Bathrooms = editHouse.Bathrooms;
        }
        if (editHouse.Levels != null)
        {
          currentHouse.Levels = editHouse.Levels;
        }
        if (editHouse.Year != null)
        {
          currentHouse.Year = editHouse.Year;
        }
        if (editHouse.Price != null)
        {
          currentHouse.Price = editHouse.Price;
        }
        if (editHouse.Description != null)
        {
          currentHouse.Description = editHouse.Description;
        }
        if (editHouse.ImgUrl != null)
        {
          currentHouse.ImgUrl = editHouse.ImgUrl;
        }
        return currentHouse;
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> RemoveHouse(string id)
    {
      try
      {
        House houseToRemove = FAKEDB.Houses.Find(c => c.Id == id);
        if (FAKEDB.Houses.Remove(houseToRemove))
        {
          return Ok("House Removed");
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