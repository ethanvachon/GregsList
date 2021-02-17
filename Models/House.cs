using System;
using System.ComponentModel.DataAnnotations;

namespace GregsList.Models
{
  public class House
  {
    public House(int bedrooms, int bathrooms, int levels, int price, int year, string description, string imgUrl)
    {
      Bedrooms = bedrooms;
      Bathrooms = bathrooms;
      Levels = levels;
      Price = price;
      Year = year;
      Description = description;
      ImgUrl = imgUrl;
    }
    [Required]
    public int Bedrooms { get; set; }
    [Required]
    public int Bathrooms { get; set; }
    [Required]
    public int Levels { get; set; }
    [Required]
    public int Price { get; set; }
    [Required]
    public int Year { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public string ImgUrl { get; set; }
    public string Id { get; set; } = Guid.NewGuid().ToString();
  }
}