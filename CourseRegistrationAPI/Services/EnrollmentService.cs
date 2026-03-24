using CourseRegistrationAPI.Data;
using CourseRegistrationAPI.DTOs;
using CourseRegistrationAPI.Models;
using CourseRegistrationAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CourseRegistrationAPI.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EnrollmentDto>> GetAllAsync()
        {
            return await _context.Enrollments
                .Select(e => new EnrollmentDto
                {
                    Id = e.Id,
                    UserId = e.UserId,
                    CourseId = e.CourseId,
                    EnrolledAt = e.EnrolledAt
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<EnrollmentDto>> GetByUserIdAsync(int userId)
        {
            return await _context.Enrollments
                .Where(e => e.UserId == userId)
                .Select(e => new EnrollmentDto
                {
                    Id = e.Id,
                    UserId = e.UserId,
                    CourseId = e.CourseId,
                    EnrolledAt = e.EnrolledAt
                })
                .ToListAsync();
        }

        public async Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto dto)
        {
            var enrollment = new Enrollment
            {
                UserId = dto.UserId,
                CourseId = dto.CourseId
            };

            _context.Enrollments.Add(enrollment);
            await _context.SaveChangesAsync();

            return new EnrollmentDto
            {
                Id = enrollment.Id,
                UserId = enrollment.UserId,
                CourseId = enrollment.CourseId,
                EnrolledAt = enrollment.EnrolledAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var enrollment = await _context.Enrollments.FindAsync(id);
            if (enrollment == null) return false;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
