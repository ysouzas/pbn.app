using System.Text.Json;
using PBN.APP.Constants;
using PBN.APP.Data.Base;
using PBN.APP.Data.Interfaces;
using PBN.APP.Extensions;
using PBN.APP.Models;

namespace PBN.APP.Data;

public class TeamRepository : BaseHttpClient<Team>, ITeamRepository
{
    public Task<Team[]> GenerateTeams(List<Guid> ids)
    {
        var myContent = JsonSerializer.Serialize(ids);
        var byteContent = myContent.ToByteArrayContent();

        var teams = PostAsync<Team[]>(ConnectionStringConstants.TeamUrl, byteContent);

        return teams;
    }

    public Task<Team[]> GetAll()
    {
        throw new NotImplementedException();
    }
}
