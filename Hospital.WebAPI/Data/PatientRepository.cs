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

    public async Task<IEnumerable<Patient>> GetPatientsAsync()
    {
        return await _db.Patients.ToListAsync();
    }

    public async Task DeletePatientAsync(int id)
    {
        var patient = await _db.Patients.FindAsync(id);
        if (patient != null)
            _db.Patients.Remove(patient);

        await _db.SaveChangesAsync();
    }

    public async Task AddPatientAsync(Patient patient)
    {
        if (_db.Patients.Any(x => x.FirstName.Equals(patient.FirstName, StringComparison.OrdinalIgnoreCase) &&
                                  x.Surname.Equals(patient.Surname, StringComparison.OrdinalIgnoreCase) &&
                                  x.MiddleName.Equals(patient.MiddleName, StringComparison.OrdinalIgnoreCase))) return;

        _db.Patients.Add(patient);
        await _db.SaveChangesAsync();
    }

    public async Task UpdatePatientAsync(Patient patient)
    {
        if (_db.Patients.Any(x => x.Id != patient.Id &&
                             x.FirstName.Equals(patient.FirstName, StringComparison.OrdinalIgnoreCase) &&
                             x.Surname.Equals(patient.Surname, StringComparison.OrdinalIgnoreCase) &&
                             x.MiddleName.Equals(patient.MiddleName, StringComparison.OrdinalIgnoreCase))) return;

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
        }
    }

    public async Task<Patient?> GetPatientByIdAsync(int id)
    {
        return await _db.Patients.FindAsync(id);
    }
}
