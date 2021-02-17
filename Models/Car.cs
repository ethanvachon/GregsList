using System;
using System.ComponentModel.DataAnnotations;

namespace GregsList.Models
{
  public class Car
  {
    public Car(string make, string model, int year, int price, string description, string imgUrl)
    {
      Make = make;
      Model = model;
      Year = year;
      Price = price;
      Description = description;
      ImgUrl = imgUrl;
    }
    [Required]
    public string Make { get; set; }
    [Required]
    public string Model { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImgUrl { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}