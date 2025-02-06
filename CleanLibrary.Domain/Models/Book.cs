namespace CleanLibrary.Domain.Models
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public Guid AuthorId { get; private set; }

        private Book() { } 

        public Book(Guid id, string title, Guid authorId)
        {
            Id = id;
            Title = title;
            AuthorId = authorId;
        }

        public void UpdateTitle(string newTitle)
        {
            if (string.IsNullOrWhiteSpace(newTitle))
                throw new ArgumentException("Title cannot be empty or whitespace.", nameof(newTitle));

            Title = newTitle;
        }
    }
}
