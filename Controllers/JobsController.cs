using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GregsList.db;
using GregsList.Models;
using GregsList.Services;

namespace GregsList.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {

    private readonly JobsService _js;
    public JobsController(JobsService js)
    {
      _js = js;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(_js.Get());
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpGet("{id}")]
    public ActionResult<Job> Get(string id)
    {
      try
      {
        Job jobToReturn = _js.Get(id);
        return Ok(jobToReturn);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPost]
    public ActionResult<Job> Create([FromBody] Job newJob)
    {
      try
      {
        Job job = _js.Create(newJob);
        return Ok(job);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpPut("{id}")]
    public ActionResult<Job> Edit([FromBody] Job editJob, string id)
    {
      try
      {
        editJob.Id = id;
        Job job = _js.Edit(editJob);
        return Ok(job);
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }

    [HttpDelete("{id}")]
    public ActionResult<string> RemoveJob(string id)
    {
      try
      {
        _js.Delete(id);
        return Ok("deleted");
      }
      catch (System.Exception err)
      {
        return BadRequest(err.Message);
      }
    }
  }
}