using System.Text.Json;
using PBN.APP.Constants;
using PBN.APP.Data.Base;
using PBN.APP.Data.Interfaces;
using PBN.APP.DTO.Request;
using PBN.APP.Extensions;
using PBN.APP.Models;

namespace PBN.APP.Data;

public class PlayerRepository : BaseHttpClient<Player>, IPlayerRepository
{
    public async Task<Player> AddPlayer(AddPlayerDTO dto)
    {
        var myContent = JsonSerializer.Serialize(dto);
        var byteContent = myContent.ToByteArrayContent();

        var player = await PostAsync<Player>(ConnectionStringConstants.AddPlayer, byteContent);

        return player;
    }

    public async Task<Player> AddRank(AddRankDTO dto)
    {
        var myContent = JsonSerializer.Serialize(dto);
        var byteContent = myContent.ToByteArrayContent();

        var player = await PostAsync<Player>(ConnectionStringConstants.AddRankUrl, byteContent);

        return player;
    }

    public async Task<Player[]> GetAll()
    {
        var players = await GetAsync<Player[]>(ConnectionStringConstants.PlayerUrl);

        return players;

    }

    public async Task<Player> GetPlayerWithRank(Guid id)
    {
        var dto = new GetPlayerByIdDTO(id);
        var myContent = JsonSerializer.Serialize(dto);
        var byteContent = myContent.ToByteArrayContent();

        var player = await PostAsync<Player>(ConnectionStringConstants.RankUrl, byteContent);

        return player;
    }

    public async Task<string> GetRanking()
    {
        var player = await GetAsync<string>(ConnectionStringConstants.Ranking);

        return player;
    }
}