using DomainLayer.Entities;

namespace AplicationLayer.Interfaces
{
    public interface IShopRepository : IGenericRepository<Shop>
    {
        Task<Shop> GetByName(string name, CancellationToken cancellationToken);
        Task<Shop> GetById(int shopId, CancellationToken cancellationToken);
    }
}
