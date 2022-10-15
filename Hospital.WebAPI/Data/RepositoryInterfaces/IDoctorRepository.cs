using Hospital.Shared;
using Hospital.WebAPI.Dtos;

namespace Hospital.WebAPI.Data.Interfaces
{
    public interface IDoctorRepository
    {
        Task<ServiceResponse<string>> AddDoctorAsync(Doctor doctor);
        Task<ServiceResponse<string>> DeleteDoctorAsync(int id);
        Task<ServiceResponse<Doctor>> GetDoctorByIdAsync(int id);
        Task<ServiceResponse<List<DoctorDto>>> GetDoctorsAsync();
        Task<ServiceResponse<string>> UpdateDoctorAsync(Doctor doctor);
    }
}