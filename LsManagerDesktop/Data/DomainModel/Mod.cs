using System;
using System.ComponentModel.DataAnnotations;

namespace LsManagerDesktop.Data.DomainModel;

public class Mod
{
    [Key] public Guid Id { get; set; } = Guid.NewGuid();
    
    [MaxLength(150)] public string Name { get; set; } = "New Mod";
    
    [MaxLength(150)] public string Category { get; set; } = "Others";
    
    [MaxLength(150)] public string SubCategory { get; set; } = "";
    
    public Version Version { get; set; } = new Version(1, 0, 0, 0);
    
    [MaxLength(50)]
    public string ModId { get; set; } = "0";
    
    public bool IsOfficial { get; set; } = false;

    public bool IsDefault { get; set; } = false;
    
    [MaxLength(200)] public string Author { get; set; } = "";
    public string FileName { get; set; } = "";
}