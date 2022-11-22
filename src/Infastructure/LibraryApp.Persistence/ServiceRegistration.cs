using LibraryApp.Application.Interfaces.Repositories;
using LibraryApp.Persistence.Context;
using LibraryApp.Persistence.Interfaces;
using LibraryApp.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer(
                configuration.GetConnectionString("DefaultConnection")));

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IBookTransactionRepository, BookTransactionRepository>();

            //services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationDbContext>());
        }
    }
}
