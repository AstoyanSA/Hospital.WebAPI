using Hospital.Shared;
using Hospital.WebAPI.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DoctorController : ControllerBase
{
	private readonly IDoctorRepository _doctorRepository;

	public DoctorController(IDoctorRepository doctorRepository)
	{
		_doctorRepository = doctorRepository;
	}

	[HttpGet]
	public async Task<ActionResult<ServiceResponse<List<Doctor>>>> GetDoctors(string? sortField)
	{
		var result = await _doctorRepository.GetDoctorsAsync(sortField);

		return Ok(result);
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<ServiceResponse<Doctor>>> GetDoctor(int id)
	{
		var result = await _doctorRepository.GetDoctorByIdAsync(id);

		return Ok(result);
	}

	[HttpPost]
	public async Task<ActionResult<ServiceResponse<string>>> AddDoctor(Doctor doctor)
	{
		var result = await _doctorRepository.AddDoctorAsync(doctor);

		return Ok(result);
	}

	[HttpPut]
	public async Task<ActionResult<ServiceResponse<string>>> UpdateDoctor(Doctor doctor)
	{
		var result = await _doctorRepository.UpdateDoctorAsync(doctor);

		return result;
	}

	[HttpDelete("{id:int}")]
	public async Task<ActionResult<ServiceResponse<string>>> DeleteDoctor(int id)
	{
		var result = await _doctorRepository.DeleteDoctorAsync(id);

		return Ok(result);
	}
}
