using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hospital.Shared;

public class Patient
{
    public int Id { get; set; }
    public string Surname { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    [Column(TypeName = "date")]
    public DateTime Birthday { get; set; }
    public string Sex { get; set; } = string.Empty;
    public int AreaId { get; set; }
    [JsonIgnore]
    public Area? Area { get; set; }
}
