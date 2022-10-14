using Hospital.Shared;

namespace Hospital.WebAPI.Data.Interfaces
{
    public interface IPatientRepository
    {
        Task<ServiceResponse<string>> AddPatientAsync(Patient patient);
        Task<ServiceResponse<string>> DeletePatientAsync(int id);
        Task<ServiceResponse<Patient>> GetPatientByIdAsync(int id);
        Task<ServiceResponse<List<Patient>>> GetPatientsAsync();
        Task<ServiceResponse<string>> UpdatePatientAsync(Patient patient);
    }
}