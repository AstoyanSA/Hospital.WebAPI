using Hospital.Shared;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital.WebAPI.Dtos;

public class PatientDto
{
    public int Id { get; set; }
    public string Surname { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    [Column(TypeName = "date")]
    public DateTime Birthday { get; set; }
    public string Sex { get; set; } = string.Empty;
    public int AreaNumber { get; set; }

}
