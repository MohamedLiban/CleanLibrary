namespace CleanLibrary.Domain.Models
{
    public class Author
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Author() { }

        public Author(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        
        public void UpdateName(string newName)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("Name cannot be empty or whitespace.", nameof(newName));

            Name = newName;
        }
    }
}
