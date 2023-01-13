namespace ProjetDotNet.Models;
using System.ComponentModel.DataAnnotations;


public class Post
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public User Author { get; set; }
    [Required]
    public string Date { get; set; }
    
    

}