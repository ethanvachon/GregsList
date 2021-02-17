using System;
using System.ComponentModel.DataAnnotations;

namespace GregsList.Models
{
  public class Job
  {
    public Job(string company, string jobTitle, int hours, int rate, string description)
    {
      Company = company;
      JobTitle = jobTitle;
      Hours = hours;
      Rate = rate;
      Description = description;
    }
    [Required]
    public string Company { get; set; }
    [Required]
    public string JobTitle { get; set; }
    [Required]
    public int Hours { get; set; }
    [Required]
    public int Rate { get; set; }
    [Required]
    public string Description { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}