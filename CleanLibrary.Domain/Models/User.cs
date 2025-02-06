namespace CleanLibrary.Domain.Models
{
    public class User
    {
        public Guid Id { get; private set; }
        public string Username { get; private set; }
        public string FirstName { get; set; }  
        public string LastName { get; set; }   
        public string Email { get; set; }      
        public string PasswordHash { get; private set; }

        public User(Guid id, string username, string firstName, string lastName, string email, string passwordHash)
        {
            Id = id;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
