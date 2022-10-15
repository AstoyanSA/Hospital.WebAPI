using System.Text.Json.Serialization;

namespace Hospital.Shared;

public class Doctor
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int CabinetId { get; set; }
    [JsonIgnore]
    public Cabinet? Cabinet { get; set; }
    public int SpecializationId { get; set; }
    [JsonIgnore]
    public Specialization? Specialization { get; set; }
    public int? AreaId { get; set; }
    [JsonIgnore]
    public Area? Area { get; set; }
}
