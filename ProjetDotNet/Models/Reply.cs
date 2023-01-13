﻿namespace ProjetDotNet.Models;
using System.ComponentModel.DataAnnotations;


public class Reply
{
    
    public int Id { get; set; }
    [Required]
    public string Content { get; set; }
    [Required]
    public Post Post { get; set; }
    [Required]
    public User Author { get; set; }
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public Boolean IsAccepted { get; set; }
    
    
    
}