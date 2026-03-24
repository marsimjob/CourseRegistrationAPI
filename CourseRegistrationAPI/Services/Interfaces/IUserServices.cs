using CourseRegistrationAPI.DTOs;

namespace CourseRegistrationAPI.Services.Interfaces
{
    public interface IUserService
    {
        // Hämtar alla användare från databasen
        Task<IEnumerable<UserDto>> GetAllAsync();

        // Hämtar en specifik användare baserat på id
        Task<UserDto?> GetByIdAsync(int id);

        // Skapar en ny användare och returnerar den skapade användaren
        Task<UserDto> CreateAsync(CreateUserDto dto);

        // Uppdaterar en befintlig användare, returnerar null om den inte finns
        Task<UserDto?> UpdateAsync(int id, CreateUserDto dto);

        // Tar bort en användare, returnerar false om den inte finns
        Task<bool> DeleteAsync(int id);
    }
}