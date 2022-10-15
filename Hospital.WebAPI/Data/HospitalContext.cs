using Hospital.Shared;
using Microsoft.EntityFrameworkCore;

namespace Hospital.WebAPI.Data;

public class HospitalContext : DbContext
{
    public DbSet<Area> Areas { get; set; } = null!;
    public DbSet<Specialization> Specializations { get; set; } = null!;
    public DbSet<Cabinet> Cabinets { get; set; } = null!;
    public DbSet<Patient> Patients { get; set; } = null!;
    public DbSet<Doctor> Doctors { get; set; } = null!;

    public HospitalContext(DbContextOptions<HospitalContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        #region SetAreaData
        modelBuilder.Entity<Area>().HasData(
            new Area
            {
                Id = 1,
                AreaNumber = 13,
            },

            new Area
            {
                Id = 2,
                AreaNumber = 4,
            },

            new Area
            {
                Id = 3,
                AreaNumber = 46,
            },

            new Area
            {
                Id = 4,
                AreaNumber = 8,
            }

            );
        #endregion

        #region SetCabinetData
        modelBuilder.Entity<Cabinet>().HasData(
            new Cabinet
            {
                Id = 1,
                CabNumber = 4
            },

            new Cabinet
            {
                Id = 2,
                CabNumber = 7
            },

            new Cabinet
            {
                Id = 3,
                CabNumber = 12
            },

            new Cabinet
            {
                Id = 4,
                CabNumber = 6
            },

            new Cabinet
            {
                Id = 5,
                CabNumber = 8
            },

            new Cabinet
            {
                Id = 6,
                CabNumber = 10
            }

            );
        #endregion

        #region SetSpecData
        modelBuilder.Entity<Specialization>().HasData(
            new Specialization
            {
                Id = 1,
                SpecName = "Педиатрия"
            },

            new Specialization
            {
                Id = 2,
                SpecName = "Хирургия"
            },

            new Specialization
            {
                Id = 3,
                SpecName = "Флебология"
            },

            new Specialization
            {
                Id = 4,
                SpecName = "Колопроктология"
            }

            );
        #endregion

        #region SetPatientData
        modelBuilder.Entity<Patient>().HasData(
            new Patient
            {
                Id = 1,
                Surname = "Петров",
                FirstName = "Денис",
                MiddleName = "Евгеньевич",
                Address = "улица Степная, дом 130",
                Birthday = new DateTime(1980, 10, 10),
                Sex = "М",
                AreaId = 4,
            },

            new Patient
            {
                Id = 2,
                Surname = "Иванов",
                FirstName = "Олег",
                MiddleName = "Сергеевич",
                Address = "улица Калинина, дом 6",
                Birthday = new DateTime(1994, 6, 1),
                Sex = "М",
                AreaId = 2,
            },

            new Patient
            {
                Id = 3,
                Surname = "Смирнов",
                FirstName = "Сергей",
                MiddleName = "Иванович",
                Address = "улица Гоголя, дом 12, квартира 8",
                Birthday = new DateTime(2000, 2, 24),
                Sex = "М",
                AreaId = 2,
            },

            new Patient
            {
                Id = 4,
                Surname = "Жукова",
                FirstName = "Анастасия",
                MiddleName = "Николаевна",
                Address = "улица Красная, дом 5",
                Birthday = new DateTime(1988, 4, 13),
                Sex = "м",
                AreaId = 3,
            },

            new Patient
            {
                Id = 5,
                Surname = "Ульянов",
                FirstName = "Алексей",
                MiddleName = "Сергеевич",
                Address = "улица Мира, дом 64",
                Birthday = new DateTime(2007, 12, 10),
                Sex = "ж",
                AreaId = 1,
            }

            );
        #endregion

        #region SetDoctorData
        modelBuilder.Entity<Doctor>().HasData(
            new Doctor
            {
                Id = 1,
                FullName = "Попов Даниил Викторович",
                CabinetId = 2,
                SpecializationId = 3
            },

            new Doctor
            {
                Id = 2,
                FullName = "Соколов Виктор Петрович",
                CabinetId = 3,
                SpecializationId = 2
            },

            new Doctor
            {
                Id = 3,
                FullName = "Михайлов Игорь Львович",
                CabinetId = 1,
                SpecializationId = 1,
                AreaId = 2,
            },

            new Doctor
            {
                Id = 4,
                FullName = "Федоров Богдан Антонович",
                CabinetId = 6,
                SpecializationId = 4,
            }

            );
        #endregion
    }
}
