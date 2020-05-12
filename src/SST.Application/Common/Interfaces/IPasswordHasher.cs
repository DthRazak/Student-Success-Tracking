namespace SST.Application.Common.Interfaces
{
    public interface IPasswordHasher
    {
        public string GetPasswordHash(string password);
    }
}
