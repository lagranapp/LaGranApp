namespace LaGranAppCAS.Security
{
    public interface ICASAuthenticationService
    {
        CASUser AuthenticatedUser { get; }
        CASUser AuthenticateUser(string username, string password);
        string CalculateHash(string clearTextPassword, string salt);
    }
}
