using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using GregsList.db;
using GregsList.Models;

namespace GregsList.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class JobsController : ControllerBase
  {
    [HttpGet]
    public ActionResult<IEnumerable<Job>> Get()
    {
      try
      {
        return Ok(FAKEDB.Jobs);
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
        Job jobToReturn = FAKEDB.Jobs.Find(c => c.Id == id);
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
        FAKEDB.Jobs.Add(newJob);
        return Ok(newJob);
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
        Job currentJob = FAKEDB.Jobs.Find(c => c.Id == id);
        if (editJob.Company != null)
        {
          currentJob.Company = editJob.Company;
        }
        if (editJob.JobTitle != null)
        {
          currentJob.JobTitle = editJob.JobTitle;
        }
        if (editJob.Hours != null)
        {
          currentJob.Hours = editJob.Hours;
        }
        if (editJob.Rate != null)
        {
          currentJob.Rate = editJob.Rate;
        }
        if (editJob.Description != null)
        {
          currentJob.Description = editJob.Description;
        }
        return currentJob;
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
        Job jobToRemove = FAKEDB.Jobs.Find(c => c.Id == id);
        if (FAKEDB.Jobs.Remove(jobToRemove))
        {
          return Ok("Job Removed");
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