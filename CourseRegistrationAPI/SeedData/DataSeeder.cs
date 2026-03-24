using Bogus;
using CourseRegistrationAPI.Data;
using CourseRegistrationAPI.Models;

namespace CourseRegistrationAPI.SeedData
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;

        public DataSeeder(AppDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Kör bara om databasen är tom
            if (_context.Users.Any()) return;

            // Skapar 10 fejkade användare med Bogus
            var userFaker = new Faker<User>("sv")
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.Role, f => f.PickRandom("Student", "Admin"));

            var users = userFaker.Generate(10);
            _context.Users.AddRange(users);

            // Skapar 5 fejkade kurser med Bogus
            var courseFaker = new Faker<Course>("sv")
                .RuleFor(c => c.Title, f => f.Lorem.Sentence(3))
                .RuleFor(c => c.Description, f => f.Lorem.Paragraph())
                .RuleFor(c => c.Credits, f => f.Random.Int(1, 30));

            var courses = courseFaker.Generate(5);
            _context.Courses.AddRange(courses);

            _context.SaveChanges();

            // Registrerar varje användare på en slumpmässig kurs
            var enrollmentFaker = new Faker<Enrollment>()
                .RuleFor(e => e.UserId, f => f.PickRandom(users).Id)
                .RuleFor(e => e.CourseId, f => f.PickRandom(courses).Id)
                .RuleFor(e => e.EnrolledAt, f => f.Date.Recent(30));

            var enrollments = enrollmentFaker.Generate(15);
            _context.Enrollments.AddRange(enrollments);

            _context.SaveChanges();
        }
    }
}