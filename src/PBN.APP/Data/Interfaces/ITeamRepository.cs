using PBN.APP.Models;

namespace PBN.APP.Data.Interfaces;

public interface ITeamRepository : IRepository<Team>
{
    Task<Team[]> GenerateTeams(List<Guid> ids);
}
