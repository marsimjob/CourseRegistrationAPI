using CourseRegistrationAPI.DTOs;

namespace CourseRegistrationAPI.Services.Interfaces
{
    public interface IEnrollmentService
    {
        // Hämtar alla registreringar från databasen
        Task<IEnumerable<EnrollmentDto>> GetAllAsync();

        // Hämtar alla kurser som en specifik användare är registrerad på
        Task<IEnumerable<EnrollmentDto>> GetByUserIdAsync(int userId);

        // Registrerar en användare på en kurs
        Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto dto);

        // Tar bort en registrering, returnerar false om den inte finns
        Task<bool> DeleteAsync(int id);
    }
}