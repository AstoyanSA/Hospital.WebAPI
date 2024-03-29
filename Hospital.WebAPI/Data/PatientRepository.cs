﻿using Hospital.Shared;
using Hospital.WebAPI.Data.Interfaces;
using Hospital.WebAPI.Dtos;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebAPI.Data;

public class PatientRepository : IPatientRepository
{
    private readonly HospitalContext _db;

    public PatientRepository(HospitalContext db)
    {
        _db = db;
    }

    public async Task<ServiceResponse<List<PatientDto>>> GetPatientsAsync(string? sortField, int page, int count)
    {
        var query = await (from p in _db.Patients
                           join a in _db.Areas on p.AreaId equals a.Id
                           select new
                           {
                               p.Id,
                               p.Surname,
                               p.FirstName,
                               p.MiddleName,
                               p.Address,
                               p.Birthday,
                               p.Sex,
                               a.AreaNumber
                           }).ToListAsync();

        List<PatientDto> patientDto = new();

        if (!string.IsNullOrWhiteSpace(sortField))
        {
            string sortTrim = sortField.Trim();
            if(String.Equals(typeof(PatientDto)?.GetProperty(sortTrim)?.Name, sortTrim))
            {
                //patientDto.Sort((p1, p2) => string.Compare(p1?.GetType()?.GetProperty(sortField)?.GetValue(p1)?.ToString(), p2?.GetType()?.GetProperty(sortField)?.GetValue(p2)?.ToString()));
                string? sort = typeof(PatientDto)?.GetProperty(sortTrim)?.Name.ToLower();

                switch (sort)
                {
                    case "id":
                        query.Sort((p1, p2) => Decimal.Compare(p1.Id, p2.Id));
                        break;
                    case "surname":
                        query.Sort((p1, p2) => string.Compare(p1.Surname, p2.Surname));
                        break;
                    case "firstname":
                        query.Sort((p1, p2) => string.Compare(p1.FirstName, p2.FirstName));
                        break;
                    case "middlename":
                        query.Sort((p1, p2) => string.Compare(p1.MiddleName, p2.MiddleName));
                        break;
                    case "address":
                        query.Sort((p1, p2) => string.Compare(p1.Address, p2.Address));
                        break;
                    case "birthday":
                        query.Sort((p1, p2) => DateTime.Compare(p1.Birthday, p2.Birthday));
                        break;
                    case "sex":
                        query.Sort((p1, p2) => string.Compare(p1.Sex, p2.Sex));
                        break;
                    case "areanumber":
                        query.Sort((p1, p2) => Decimal.Compare(p1.AreaNumber, p2.AreaNumber));
                        break;
                }
            }
        }

        foreach(var q in query)
        {
            patientDto.Add(new PatientDto {
                Id = q.Id,
                Surname = q.Surname,
                FirstName = q.FirstName,
                MiddleName = q.MiddleName,
                Address = q.Address,
                Birthday = q.Birthday,
                Sex = q.Sex,
                AreaNumber = q.AreaNumber
            });
        }

        var response = new ServiceResponse<List<PatientDto>>
        {
            Data = patientDto.Skip((page - 1) * count).Take(count).ToList()
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
            #region With Check if the patient with this data alredy exists
            /*
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
                _db.Patients.Add(new Patient
                {
                    Surname = patient.Surname,
                    FirstName = patient.FirstName,
                    MiddleName = patient.MiddleName,
                    Address = patient.Address,
                    Birthday = patient.Birthday,
                    Sex = patient.Sex,
                    AreaId = patient.AreaId
                });
                await _db.SaveChangesAsync();
                response.Data = "Пациент добавлен.";
            }
            */
            #endregion

            _db.Patients.Add(new Patient
            {
                Surname = patient.Surname,
                FirstName = patient.FirstName,
                MiddleName = patient.MiddleName,
                Address = patient.Address,
                Birthday = patient.Birthday,
                Sex = patient.Sex,
                AreaId = patient.AreaId
            });
            await _db.SaveChangesAsync();
            response.Data = "Пациент добавлен.";

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
            #region With Check if the patient with this data alredy exists
            /*
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

                    await _db.SaveChangesAsync();

                    response.Data = "Данные пациента обновлены";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Такого пациента не существует.";
                }
            }
            */
            #endregion

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

                await _db.SaveChangesAsync();

                response.Data = "Данные пациента обновлены";
            }
            else
            {
                response.Success = false;
                response.Message = "Такого пациента не существует.";
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
