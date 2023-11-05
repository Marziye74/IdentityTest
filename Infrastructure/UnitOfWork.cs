
using AplicationLayer.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repository;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _AppDbContext;
        public IShopRepository ShopRepository { get; set; }
        public UnitOfWork(AppDbContext appDbContext)
        {
            _AppDbContext = appDbContext;
            ShopRepository = new ShopRepository(_AppDbContext);
        }

        public void SaveChanges()
        {
            using (var transaction = _AppDbContext.Database.BeginTransaction())
            {
                try
                {
                    if (transaction.SupportsSavepoints)
                        transaction.CreateSavepoint("BeforeSaveChanges");

                    _AppDbContext.SaveChanges();

                    transaction.Commit();
                }
                catch
                {
                    if (transaction.SupportsSavepoints)
                        transaction.RollbackToSavepoint("BeforeSaveChanges");

                    throw;
                }
            }
        }
        public async Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            using (var transaction = await _AppDbContext.Database.BeginTransactionAsync(cancellationToken))
            {
                try
                {
                    if (transaction.SupportsSavepoints)
                        await transaction.CreateSavepointAsync("BeforeSaveChangesAsync", cancellationToken);

                    await _AppDbContext.SaveChangesAsync(cancellationToken);

                    await transaction.CommitAsync(cancellationToken);
                }
                catch
                {
                    if (transaction.SupportsSavepoints)
                        await transaction.RollbackToSavepointAsync("BeforeSaveChangesAsync", cancellationToken);
                }
            }
        }
    }
}
