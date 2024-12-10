using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Data.DomainModel;

[Table("Settings")]
public class Setting
{
    [Key] public string Key { get; set; } = "Key";
    [Required] public string Value { get; set; } = "";
}

public static class Settings
{
    public const string ModDbPath = "ModDbPath";
}
