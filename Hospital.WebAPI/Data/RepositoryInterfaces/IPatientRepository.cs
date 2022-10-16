using Hospital.Shared;
using Hospital.WebAPI.Dtos;

namespace Hospital.WebAPI.Data.Interfaces
{
    public interface IPatientRepository
    {
        Task<ServiceResponse<string>> AddPatientAsync(Patient patient);
        Task<ServiceResponse<string>> DeletePatientAsync(int id);
        Task<ServiceResponse<Patient>> GetPatientByIdAsync(int id);
        Task<ServiceResponse<List<PatientDto>>> GetPatientsAsync(string? sortField, int page, int count);
        Task<ServiceResponse<string>> UpdatePatientAsync(Patient patient);
    }
}