using Hospital.Shared;
using Hospital.WebAPI.Data.Interfaces;
using Hospital.WebAPI.Dtos;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Hospital.WebAPI.Data;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalContext _db;

    public PatientRepository(HospitalContext db)
    {
        _db = db;
    }

    public async Task<ServiceResponse<List<PatientDto>>> GetPatientsAsync()
    {
        var query = await (from p in _db.Patients
                           join a in _db.Areas on p.AreaId equals a.Id
                           select new
                           {
                               p.Surname,
                               p.FirstName,
                               p.MiddleName,
                               p.Address,
                               p.Birthday,
                               p.Sex,
                               a.Number
                           }).ToListAsync();

        List<PatientDto> patientDto = new();

        foreach(var q in query)
        {
            patientDto.Add(new PatientDto {
                Surname = q.Surname,
                FirstName = q.FirstName,
                MiddleName = q.MiddleName,
                Address = q.Address,
                Birthday = q.Birthday,
                Sex = q.Sex,
                AreaNumber = q.Number
            });
        }

        var response = new ServiceResponse<List<PatientDto>>
        {
            Data = patientDto
        };

        return response;
    }

    public async Task<ServiceResponse<string>> DeletePatientAsync(int id)
    {
        var response = new ServiceResponse<string>();
        try
        {
            var patient = await _db.Patients.FindAsync(id);
            if (patient != null)
            {
                _db.Patients.Remove(patient);
                await _db.SaveChangesAsync();

                response.Data = $"Удален {patient.FirstName} {patient.Surname}.";
            }
            else
            {
                response.Success = false;
                response.Message = "Не удалось удалить (пациент не найден).";
            }

            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;

            return response;
        }
    }

    public async Task<ServiceResponse<string>> AddPatientAsync(Patient patient)
    {
        var response = new ServiceResponse<string>();
        try
        {
            if (_db.Patients.Any(x => x.Surname.ToLower().Equals(patient.Surname.ToLower()) &&
                                 x.FirstName.ToLower().Equals(patient.FirstName.ToLower()) &&
                                 x.MiddleName.ToLower().Equals(patient.MiddleName.ToLower()) &&
                                 x.Address.ToLower().Trim().Equals(patient.Address.ToLower()) &&
                                 x.Birthday == patient.Birthday &&
                                 x.Sex.Equals(patient.Sex) &&
                                 x.AreaId == patient.AreaId))
            {
                response.Success = false;
                response.Message = "Не удалось добавить, такой пациент уже существует.";
            }
            else
            {
                _db.Patients.Add(patient);
                await _db.SaveChangesAsync();
                response.Data = "Пациент добавлен.";
            }

            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;

            return response;
        }
    }

    public async Task<ServiceResponse<string>> UpdatePatientAsync(Patient patient)
    {
        var response = new ServiceResponse<string>();
        try
        {
            if (_db.Patients.Any(x => x.Id != patient.Id &&
                                 x.Surname.ToLower().Equals(patient.Surname.ToLower()) &&
                                 x.FirstName.ToLower().Equals(patient.FirstName.ToLower()) &&
                                 x.MiddleName.ToLower().Equals(patient.MiddleName.ToLower()) &&
                                 x.Address.ToLower().Trim().Equals(patient.Address.ToLower()) &&
                                 x.Birthday == patient.Birthday &&
                                 x.Sex.Equals(patient.Sex) &&
                                 x.AreaId == patient.AreaId))
            {
                response.Success = false;
                response.Message = "Пациент с такими данными уже существует.";
            }
            else
            {
                var pat = await _db.Patients.FindAsync(patient.Id);

                if (pat != null)
                {
                    pat.Surname = patient.Surname;
                    pat.FirstName = patient.FirstName;
                    pat.MiddleName = patient.MiddleName;
                    pat.Address = patient.Address;
                    pat.Birthday = patient.Birthday;
                    pat.Sex = patient.Sex;
                    pat.AreaId = patient.AreaId;

                    response.Data = "Данные пациента обновлены";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Такого пациента не существует.";
                }
            }

            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;

            return response;
        }
    }

    public async Task<ServiceResponse<Patient>> GetPatientByIdAsync(int id)
    {
        var response = new ServiceResponse<Patient>();
        try
        {
            var patient = await _db.Patients.FindAsync(id);

            if (patient != null)
                response.Data = patient;
            else
            {
                response.Success = false;
                response.Message = "Пациент не найден.";
            }

            return response;
        }
        catch (Exception ex)
        {
            response.Success = false;
            response.Message = ex.Message;

            return response;
        }
    }
}
