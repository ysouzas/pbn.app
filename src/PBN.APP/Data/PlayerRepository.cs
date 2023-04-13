using PBN.APP.Constants;
using PBN.APP.Data.Base;
using PBN.APP.Data.Interfaces;
using PBN.Models;

namespace PBN.APP.Data;

public class PlayerRepository : BaseHttpClient<Player>, IPlayerRepository
{

    public async Task<Player[]> GetAll()
    {
        var players = await GetAsync<Player[]>(ConnectionStringConstants.PlayerUrl);

        return players;

    }
}