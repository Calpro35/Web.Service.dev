using MediatR;
using Web.Service.Cap7.UseCases.NewUserUseCase;
using FluentValidation;
using Web.Service.Cap7.Data.Context;
using Web.Service.Cap7.Interfaces;
using Web.Service.Cap7.Services;
using Microsoft.EntityFrameworkCore;
using Web.Service.Cap7.Data.Repositories;
using Web.Service.Cap7.Boundaries;
using AutoMapper;
using Web.Service.Cap7.Models;
using Web.Service.Cap7.ViewModels;

namespace Web.Service.Cap7.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddMapper(this IServiceCollection services, IConfiguration configuration)
    {
        var mapperConfig = new AutoMapper.MapperConfiguration(c => {
            // Permite que coleções nulas sejam mapeadas
            c.AllowNullCollections = true;
            // Permite que valores de destino nulos sejam mapeados
            c.AllowNullDestinationValues = true;

            c.CreateMap<User, UserViewModel>();
            c.CreateMap<UserViewModel, User>();
            c.CreateMap<Sector, SectorViewModel>();
            c.CreateMap<SectorViewModel, Sector>();
            c.CreateMap<Equipment, EquipmentViewModel>();
            c.CreateMap<EquipmentViewModel, Equipment>();

        });
        // Cria o mapper com base na configuração definida
        IMapper mapper = mapperConfig.CreateMapper();
        // Registra o IMapper como um serviço singleton no container de DI do ASP.NET Core
        services.AddSingleton(mapper);

        return services;
    }

    public static IServiceCollection AddMediatr(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssembly(typeof(NewUser).Assembly);
        });

        services.AddValidatorsFromAssembly(typeof(NewUser).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

        return services;
    }

    public static IServiceCollection AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories(configuration);
        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        serviceCollection.AddDbContext<AppDbContext>(options =>
        {
            
            options.UseNpgsql(connectionString);
        });

        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IPasswordService, PasswordService>();
        serviceCollection.AddScoped<ISectorRepository, SectorRepository>();
        serviceCollection.AddScoped<IEquipmentRepository, EquipmentRepository>();
        serviceCollection.AddScoped<ISectorService, SectorService>();

        return serviceCollection;
    }
}