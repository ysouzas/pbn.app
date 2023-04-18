using PBN.APP.DTO.Request;
using PBN.Models;

namespace PBN.APP.Services.Interfaces;

public interface IPlayerService : IService<Player>
{
    public Task<Player[]> GetAll();

    Task<Player> GetPlayerWithRank(Guid id);

    Task<Player> AddRank(AddRankDTO dto);
}