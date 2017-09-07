using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using AddressBook.Dal.Abstract;
using AddressBook.Dal.SqlServer;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class AddressBookDalSqlServerServiceCollectionExtention
    {
        public static IServiceCollection AddAddressBookDalSqlServer(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<AddressBookContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("AddressBook.Dal.SqlServer")));

            services.AddScoped<IDalRepository, DalRepository>();
            return services;
        }
    }
}
