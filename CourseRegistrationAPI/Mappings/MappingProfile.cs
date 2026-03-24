using AutoMapper;
using CourseRegistrationAPI.DTOs;
using CourseRegistrationAPI.Models;

namespace CourseRegistrationAPI.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // User -> UserDto: Konverterar User-modellen till ett DTO som skickas tillbaka till klienten
        // CreateUserDto -> User: Konverterar inkommande data från klienten till en User-modell som sparas i DB
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDto, User>();

        // Course -> CourseDto: Konverterar Course-modellen till ett DTO som skickas tillbaka till klienten
        // CreateCourseDto -> Course: Konverterar inkommande data från klienten till en Course-modell som sparas i DB
        CreateMap<Course, CourseDto>();
        CreateMap<CreateCourseDto, Course>();

        // Enrollment -> EnrollmentDto: Konverterar Enrollment-modellen till ett DTO som skickas tillbaka till klienten
        // CreateEnrollmentDto -> Enrollment: Konverterar inkommande data från klienten till en Enrollment-modell som sparas i DB
        CreateMap<Enrollment, EnrollmentDto>();
        CreateMap<CreateEnrollmentDto, Enrollment>();
    }
}
