using Hospital.Shared;
using Hospital.WebAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebAPI.Data;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalContext _db;

    public PatientRepository(HospitalContext db)
    {
        _db = db;
    }

    public async Task<ServiceResponse<List<Patient>>> GetPatientsAsync()
    {
        var response = new ServiceResponse<List<Patient>>
        {
            Data = await _db.Patients.ToListAsync()
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
            if (_db.Patients.Any(x => x.FirstName.Equals(patient.FirstName, StringComparison.OrdinalIgnoreCase) &&
                                      x.Surname.Equals(patient.Surname, StringComparison.OrdinalIgnoreCase) &&
                                      x.MiddleName.Equals(patient.MiddleName, StringComparison.OrdinalIgnoreCase)))
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
                             x.FirstName.Equals(patient.FirstName, StringComparison.OrdinalIgnoreCase) &&
                             x.Surname.Equals(patient.Surname, StringComparison.OrdinalIgnoreCase) &&
                             x.MiddleName.Equals(patient.MiddleName, StringComparison.OrdinalIgnoreCase) &&
                             x.Address.Trim().Equals(patient.Address, StringComparison.OrdinalIgnoreCase) &&
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
                    pat.FirstName = patient.FirstName;
                    pat.Surname = patient.Surname;
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
