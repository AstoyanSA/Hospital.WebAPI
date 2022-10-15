using Hospital.Shared;
using Hospital.WebAPI.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebAPI.Data;

public class DoctorRepository : IDoctorRepository
{
    private readonly HospitalContext _db;

    public DoctorRepository(HospitalContext db)
    {
        _db = db;
    }

    public async Task<ServiceResponse<List<Doctor>>> GetDoctorsAsync()
    {
        var response = new ServiceResponse<List<Doctor>>
        {
            Data = await _db.Doctors.ToListAsync()
        };

        return response;
    }

    public async Task<ServiceResponse<string>> DeleteDoctorAsync(int id)
    {
        var response = new ServiceResponse<string>();
        try
        {
            var doctor = await _db.Doctors.FindAsync(id);
            if (doctor != null)
            {
                _db.Doctors.Remove(doctor);
                await _db.SaveChangesAsync();

                response.Data = $"Удален врач {doctor.FullName}.";
            }
            else
            {
                response.Success = false;
                response.Message = "Не удалось удалить (врач не найден).";
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

    public async Task<ServiceResponse<string>> AddDoctorAsync(Doctor doctor)
    {
        var response = new ServiceResponse<string>();
        try
        {
            if (_db.Doctors.Any(x => x.FullName.Trim().ToLower().Equals(doctor.FullName.Trim().ToLower())))
            {
                response.Success = false;
                response.Message = "Не удалось добавить, такой врач уже существует.";
            }
            else
            {
                _db.Doctors.Add(doctor);
                await _db.SaveChangesAsync();
                response.Data = "Врач добавлен.";
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

    public async Task<ServiceResponse<string>> UpdateDoctorAsync(Doctor doctor)
    {
        var response = new ServiceResponse<string>();
        try
        {
            if (_db.Doctors.Any(x => x.FullName.Trim().ToLower().Equals(doctor.FullName.Trim().ToLower())))
            {
                response.Success = false;
                response.Message = "Врач с такими данными уже существует.";
            }
            else
            {
                var doc = await _db.Doctors.FindAsync(doctor.Id);

                if (doc != null)
                {
                    doc.FullName = doctor.FullName;
                    doc.CabinetId = doctor.CabinetId;
                    doc.SpecializationId = doctor.SpecializationId;
                    doc.AreaId = doctor.AreaId;

                    await _db.SaveChangesAsync();

                    response.Data = "Данные врача обновлены.";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Такого врача не существует.";
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

    public async Task<ServiceResponse<Doctor>> GetDoctorByIdAsync(int id)
    {
        var response = new ServiceResponse<Doctor>();
        try
        {
            var doctor = await _db.Doctors.FindAsync(id);

            if (doctor != null)
                response.Data = doctor;
            else
            {
                response.Success = false;
                response.Message = "Врач не найден.";
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
