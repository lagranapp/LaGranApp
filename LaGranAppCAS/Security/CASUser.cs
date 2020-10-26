namespace LaGranAppCAS.Security
{
    public class CASUser : ICASUser
    {
        public CASUser(string username, string email, string[] roles, int id)
        {
            Username = username;
            Email = email;
            Roles = roles;
            Id = id;
        }
        public string Username
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string[] Roles
        {
            get;
            set;
        }
        public int Id { get; set; }
    }
}
