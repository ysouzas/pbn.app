using PBN.APP.Data;
using PBN.APP.Data.Interfaces;
using PBN.APP.Services;
using PBN.APP.Services.Interfaces;
using PBN.APP.View;
using PBN.APP.ViewModel;

namespace PBN.APP.Configuration;

public static class DependecyInjetionConfiguration
{
    public static void RegisterData(this IServiceCollection services)
    {
        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();

    }

    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ITeamService, TeamService>();
        services.AddScoped<IPlayerService, PlayerService>();
    }

    public static void RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<PlayersViewModel>();
        services.AddSingleton<TeamsViewModel>();
    }


    public static void RegisterPages(this IServiceCollection services)
    {
        services.AddSingleton<MainPage>();
        services.AddSingleton<TeamsPage>();

    }
}
