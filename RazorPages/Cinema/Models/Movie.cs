using System.ComponentModel.DataAnnotations;
namespace Cinema.Models;

public class Movie{
    public int ID { get; set; }
    public string? Title { get; set; } 
    public string? Genre { get; set; }
    public double Rating { get; set; }
    public DateTime Date { get; set; }
}
