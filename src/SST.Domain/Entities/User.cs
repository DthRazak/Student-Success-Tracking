namespace SST.Domain.Entities
{
    public class User
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public bool IsAdmin { get; set; }

        public Request Request { get; set; }

        public Student Student { get; set; }

        public Lector Lector { get; set; }
    }
}
