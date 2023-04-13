using PBN.APP.Data.Interfaces;
using PBN.APP.Services.Interfaces;
using PBN.Models;

namespace PBN.APP.Services;

public class TeamService : ITeamService
{
    private readonly ITeamRepository repository;

    public TeamService(ITeamRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Team[]> GenerateTeams(List<string> ids)
    {
        var teams = await repository.GenerateTeams(ids);
        return teams;
    }

    public string GetTeamsAsString(Team[] teams)
    {
        var teamsToPrint = "";

        for (int i = 0; i < teams.Length; i++)
        {
            var team = teams[i];
            teamsToPrint += $"Time {i + 1} - Score: {team.Score:0.00}\n";

            foreach (var player in team.Players)
            {
                teamsToPrint += $"{player.Name} - {player.Score:0.00}\n";

            }

            teamsToPrint += "-----------------------------------\n";
        }

        return teamsToPrint;
    }
}
