namespace ApiMoodleClone.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public Roles Role { get; set; }

        public User(string username, string passwordHash, Roles role)
        {
            Username = username;
            PasswordHash = passwordHash;
            Role = role;
        }

        public enum Roles
        {
            Admin,
            Teacher,
            User,
        }
    }
}
