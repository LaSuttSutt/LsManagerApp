using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LsManagerDesktop.Data.DomainModel;

[Table("Mods")]
public class Mod
{
    [Key] public Guid Id { get; init; } = Guid.NewGuid();

    [MaxLength(150)] public string Category { get; set; } = "Others";

    [MaxLength(150)] public string SubCategory { get; set; } = "";

    [MaxLength(75)] public string Version { get; set; } = new Version(1, 0, 0, 0).ToString();

    [MaxLength(50)] public string ModId { get; set; } = "0";

    public bool IsOfficial { get; set; } = false;

    public bool IsDefault { get; set; } = false;

    [MaxLength(200)] public string Author { get; set; } = "";
    public string FileName { get; set; } = "";
}