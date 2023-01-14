namespace ProjetDotNet.Models;

using System.ComponentModel;
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
    public DateTime Date { get; set; }
    [Required]
    [DefaultValue(0)]
    public int Upvotes { get; set; }
}