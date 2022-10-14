using Hospital.Shared;
using Hospital.WebAPI.Data.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PatientController : ControllerBase
{
	private readonly IPatientRepository _patientRepository;

	public PatientController(IPatientRepository patientRepository)
	{
		_patientRepository = patientRepository;
	}

	[HttpGet]
	public async Task<ActionResult<ServiceResponse<List<Patient>>>> GetPatients()
	{
		var result = await _patientRepository.GetPatientsAsync();

        return Ok(result);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ServiceResponse<Patient>>> GetPatient(int id)
	{
        var result = await _patientRepository.GetPatientByIdAsync(id);

        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<ServiceResponse<string>>> AddPatient(Patient patient)
    {
        var result = await _patientRepository.AddPatientAsync(patient);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult<ServiceResponse<string>>> UpdatePatient(Patient patient)
    {
        var result = await _patientRepository.UpdatePatientAsync(patient);

        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<ServiceResponse<string>>> DeletePatient(int id)
    {
        var result = await _patientRepository.DeletePatientAsync(id);

        return Ok(result);
    }
}
