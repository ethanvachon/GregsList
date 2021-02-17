using System.Collections.Generic;
using System;
using GregsList.db;
using GregsList.Models;

namespace GregsList.Services
{
  public class JobsService
  {
    public IEnumerable<Job> Get()
    {
      return FAKEDB.Jobs;
    }

    public Job Get(string id)
    {
      Job jobToReturn = FAKEDB.Jobs.Find(c => c.Id == id);
      return jobToReturn;
    }

    public Job Create(Job newJob)
    {
      FAKEDB.Jobs.Add(newJob);
      return newJob;
    }

    public Job Edit(Job newJob)
    {
      Job job = FAKEDB.Jobs.Find(c => c.Id == newJob.Id);
      if (job == null)
      {
        throw new Exception("invalid Id");
      }
      FAKEDB.Jobs.Remove(job);
      FAKEDB.Jobs.Add(newJob);
      return newJob;
    }

    public string Delete(string id)
    {
      Job jobToRemove = FAKEDB.Jobs.Find(c => c.Id == id);
      if (FAKEDB.Jobs.Remove(jobToRemove))
      {
        return "Job Removed";
      }
      throw new System.Exception("invalid id");
    }
  }
}