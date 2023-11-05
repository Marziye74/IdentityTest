namespace AplicationLayer.Interfaces
{
    public interface IUnitOfWork
    {
        IShopRepository ShopRepository { get; set; }
        void SaveChanges();
        Task SaveChangesAsync(CancellationToken cancellationToken);
       
    }
}
