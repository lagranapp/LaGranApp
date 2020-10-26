namespace LaGranAppCAS.Security
{
    public interface ICASUser
    {
        string Email { get; set; }
        string[] Roles { get; set; }
        string Username { get; set; }
        int Id { get; set; }
    }
}