using System.ComponentModel.DataAnnotations;
namespace Cinema.Models;

public class Movie{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public double Rating { get; set; }
    public DateTime Date { get; set; }
}
