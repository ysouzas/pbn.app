using PBN.Models;

namespace PBN.APP.Services.Interfaces;

public interface IPlayerService : IService<Player>
{
    public Task<Player[]> GetAll();

}