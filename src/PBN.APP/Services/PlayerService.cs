using PBN.APP.Data.Interfaces;
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

    public async Task<Player[]> GetAll()
    {
        if (_players.Length > 0)
        {
            return _players;
        }

        _players = await repository.GetAll();

        return _players;
    }

}
