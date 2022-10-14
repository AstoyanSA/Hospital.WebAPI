using Hospital.Shared;

namespace Hospital.WebAPI.Data
{
    public interface IPatientRepository
    {
        Task AddPatientAsync(Patient patient);
        Task DeletePatientAsync(int id);
        Task<Patient?> GetPatientByIdAsync(int id);
        Task<IEnumerable<Patient>> GetPatientsAsync();
        Task UpdatePatientAsync(Patient patient);
    }
}