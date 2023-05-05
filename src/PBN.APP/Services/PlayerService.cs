using PBN.APP.Data.Interfaces;
using PBN.APP.DTO.Request;
using PBN.APP.Services.Interfaces;
using PBN.Models;

namespace PBN.APP.Services;

public class PlayerService : IPlayerService
{
    private readonly IPlayerRepository repository;

    private Player[] _players = Array.Empty<Player>();

    public PlayerService(IPlayerRepository repository)
    {
        this.repository = repository;
    }

    public async Task<Player> AddPlayer(AddPlayerDTO dto)
    {
        var player = await repository.AddPlayer(dto);

        return player;
    }

    public async Task<Player> AddRank(AddRankDTO dto)
    {
        var player = await repository.AddRank(dto);

        return player;
    }

    public async Task<Player[]> GetAll()
    {
        _players = await repository.GetAll();

        return _players;
    }

    public async Task<Player> GetPlayerWithRank(Guid id)
    {
        var player = await repository.GetPlayerWithRank(id);

        return player;
    }
}
