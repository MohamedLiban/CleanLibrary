namespace CleanLibrary.Test
{
    public class TestBase
    {
        protected readonly Mock<IUserRepository> UserRepositoryMock;
        protected readonly Mock<IBookRepository> BookRepositoryMock;
        protected readonly Mock<IAuthorRepository> AuthorRepositoryMock;

        public TestBase()
        {
            UserRepositoryMock = new Mock<IUserRepository>();
            BookRepositoryMock = new Mock<IBookRepository>();
            AuthorRepositoryMock = new Mock<IAuthorRepository>();
        }
    }
}
