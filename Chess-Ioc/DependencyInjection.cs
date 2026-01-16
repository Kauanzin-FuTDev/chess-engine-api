
using Chess_Application.UseCases.StartGame;
using Chess_Application.UseCases.ViewGame;
using Chess_Domain.Repository;
using Chess_infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Chess_Ioc;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
         services.AddScoped<IChessGameRepository, ChessGameRepository>();
        return services;
    }

    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<StartGameHandler>();
        services.AddScoped<ViewGameHandler>();
        return services;
    }
}