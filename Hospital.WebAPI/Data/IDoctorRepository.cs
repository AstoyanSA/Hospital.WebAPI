using Hospital.Shared;

namespace Hospital.WebAPI.Data
{
    public interface IDoctorRepository
    {
        Task AddDoctorAsync(Doctor doctor);
        Task DeleteDoctorAsync(int id);
        Task<Doctor?> GetDoctorByIdAsync(int id);
        Task<IEnumerable<Doctor>> GetDoctorsAsync();
        Task UpdateDoctorAsync(Doctor doctor);
    }
}