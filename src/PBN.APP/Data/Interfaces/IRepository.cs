namespace PBN.APP.Data.Interfaces;

public interface IRepository<T>
{
    Task<T[]> GetAll();

}
