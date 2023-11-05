using AplicationLayer.Interfaces;
using DomainLayer.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class ShopRepository : GenericRepository<Shop>, IShopRepository
    {
        public ShopRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<Shop> GetByName(string name, CancellationToken cancellationToken)
        {
            var existingName = await TableNoTracking
                .Where( m => m.Name == name)
                .FirstOrDefaultAsync(cancellationToken);
            
            return existingName;
        }

        public async Task<Shop> GetById(int shopId, CancellationToken cancellationToken)
        {
            var existingName = await TableNoTracking
                .Where(m => m.Id == shopId)
                .FirstOrDefaultAsync(cancellationToken);

            return existingName;
        }
    }
}
