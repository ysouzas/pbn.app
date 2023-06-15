using PBN.APP.DTO.Request;
using PBN.APP.Models;

namespace PBN.APP.Services.Interfaces;

public interface IPlayerService : IService<Player>
{
    public Task<Player[]> GetAll();

    Task<Player> GetPlayerWithRank(Guid id);

    Task<Player> AddRank(AddRankDTO dto);

    Task<Player> AddPlayer(AddPlayerDTO dto);

    Task<string> GetRanking();

}