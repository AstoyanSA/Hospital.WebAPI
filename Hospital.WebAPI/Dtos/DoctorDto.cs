using Hospital.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Hospital.WebAPI.Dtos;

public class DoctorDto
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public int Cabinet { get; set; }
    public int SpecializationName { get; set; }
    public int? AreaNumber { get; set; }
}
