using PBN.APP.DTO.Request;
using PBN.Models;

namespace PBN.APP.Data.Interfaces;

public interface IPlayerRepository : IRepository<Player>
{
    Task<Player> GetPlayerWithRank(Guid id);

    Task<Player> AddRank(AddRankDTO dto);

    Task<Player> AddPlayer(AddPlayerDTO dto);

    
}
