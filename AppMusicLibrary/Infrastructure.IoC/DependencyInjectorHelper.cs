using Domain.Model.Interfaces.Infrastructure;
using Domain.Model.Interfaces.Repositories;
using Domain.Model.Interfaces.Services;
using Domain.Services.Services;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Services.Queue;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.IoC
{
    public class DependencyInjectorHelper
    {
        public static void Register(
            IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<BibliotecaMusicalContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("BibliotecaMusicalContext")));

            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<IAlbumService, AlbumService>();

            services.AddScoped<IQueueMessage, QueueMessage>(provider =>
                new QueueMessage(configuration.GetValue<string>("StorageAccount")));

            services.AddScoped<IAlbumHistoricoRepository, AlbumHistoricoRepository>(provider =>
                new AlbumHistoricoRepository(configuration.GetValue<string>("StorageAccount")));

        }
    }
}
