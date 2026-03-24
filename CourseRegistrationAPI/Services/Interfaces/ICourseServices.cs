using CourseRegistrationAPI.DTOs;

namespace CourseRegistrationAPI.Services.Interfaces
{
    public interface ICourseService
    {
        // Hämtar alla kurser från databasen
        Task<IEnumerable<CourseDto>> GetAllAsync();

        // Hämtar en specifik kurs baserat på id
        Task<CourseDto?> GetByIdAsync(int id);

        // Skapar en ny kurs och returnerar den skapade kursen
        Task<CourseDto> CreateAsync(CreateCourseDto dto);

        // Uppdaterar en befintlig kurs, returnerar null om den inte finns
        Task<CourseDto?> UpdateAsync(int id, CreateCourseDto dto);

        // Tar bort en kurs, returnerar false om den inte finns
        Task<bool> DeleteAsync(int id);
    }
}