namespace PRN232.LMS.Repositories.Entities
{
    public class ApiLog
    {
        public int Id { get; set; }

        public string Path { get; set; } = string.Empty;

        public string Method { get; set; } = string.Empty;

        public int StatusCode { get; set; }

        public long ExecutionTimeMs { get; set; }

        public DateTime CreatedAt { get; set; }
    }


}