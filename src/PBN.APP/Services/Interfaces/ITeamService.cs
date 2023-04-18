using PBN.Models;

namespace PBN.APP.Services.Interfaces;

public interface ITeamService : IService<Team>
{
    public Task<Team[]> GenerateTeams(List<Guid> ids);

    public string GetTeamsAsString(Team[] teams);

}
