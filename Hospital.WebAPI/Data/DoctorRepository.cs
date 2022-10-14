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

    public async Task<IEnumerable<Doctor>> GetDoctorsAsync()
    {
        return await _db.Doctors.ToListAsync();
    }

    public async Task DeleteDoctorAsync(int id)
    {
        var doctor = await _db.Doctors.FindAsync(id);
        if (doctor != null)
            _db.Doctors.Remove(doctor);

        await _db.SaveChangesAsync();
    }

    public async Task AddDoctorAsync(Doctor doctor)
    {
        if (_db.Doctors.Any(x => x.FullName.Trim().Equals(doctor.FullName.Trim(), StringComparison.OrdinalIgnoreCase))) return;

        _db.Doctors.Add(doctor);
        await _db.SaveChangesAsync();
    }

    public async Task UpdateDoctorAsync(Doctor doctor)
    {
        if (_db.Doctors.Any(x => x.FullName.Trim().Equals(doctor.FullName.Trim(), StringComparison.OrdinalIgnoreCase))) return;

        var doc = await _db.Doctors.FindAsync(doctor.Id);

        if (doc != null)
        {
            doc.FullName = doctor.FullName;
            doc.CabinetId = doctor.CabinetId;
            doc.SpecializationId = doctor.SpecializationId;
            doc.AreaId = doctor.AreaId;
        }
    }

    public async Task<Doctor?> GetDoctorByIdAsync(int id)
    {
        return await _db.Doctors.FindAsync(id);
    }
}
