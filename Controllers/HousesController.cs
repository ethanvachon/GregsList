using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GregsList.db;
using GregsList.Models;
using GregsList.Services;

namespace GregsList.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class HousesController : ControllerBase
  {

    private readonly HousesService _hs;
    public HousesController(HousesService hs)
    {
      _hs = hs;
    }

    [HttpGet]
    public ActionResult<IEnumerable<House>> Get()
    {
      try
      {
        return Ok(_hs.Get());
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
        House houseToReturn = _hs.Get(id);
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
        House house = _hs.Create(newHouse);
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
        editHouse.Id = id;
        House house = _hs.Edit(editHouse);
        return Ok(house);
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