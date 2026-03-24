namespace CourseRegistrationAPI.DTOs
{
    public class EnrollmentDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public DateTime EnrolledAt { get; set; }
    }

    public class CreateEnrollmentDto
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
    }
}