using Microsoft.Extensions.DependencyInjection;
using CleanLibrary.Application.InterfacesRepository;
using CleanLibrary.Infrastructure.Repositories;
using CleanLibrary.Application.Users.Login.Helpers;

namespace CleanLibrary.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IAuthorRepository, AuthorRepository>();  
            services.AddScoped<IBookRepository, BookRepository>();      
            services.AddScoped<IUserRepository, UserRepository>();
            

            services.AddScoped<ITokenHelper, TokenHelper>();
            return services;
        }
    }
}
