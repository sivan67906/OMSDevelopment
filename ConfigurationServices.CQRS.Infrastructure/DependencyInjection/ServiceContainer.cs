using ConfigurationServices.CQRS.Application.Services;
using ConfigurationServices.CQRS.Domain.Interfaces;
using ConfigurationServices.CQRS.Infrastructure.Persistence;
using ConfigurationServices.CQRS.Infrastructure.Repositories;
using ConfigurationServices.CQRS.Infrastructure.Services;
using ConfigurationServices.CQRS.Infrastucture.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurationServices.CQRS.Infrastructure.DependencyInjection;

public static class ServiceContainer
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("configurationSettingsCS")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IConsumerService, ConsumerService>();
        services.AddScoped<ILeadAgentService, LeadAgentService>();
        services.AddScoped<ILeadCategoryService, LeadCategoryservice>();
        services.AddScoped<IClientService, ClientService>();
        services.AddScoped<ILeadSourceService, LeadSourceService>();
        services.AddScoped<ILeadStatusService, LeadStatusService>();

        return services;
    }
}
