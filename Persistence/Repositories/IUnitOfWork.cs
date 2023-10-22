namespace OnlineAuctionApplication.Persistence.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAuctionRepository Auctions { get; }
        IBidRepository Bids { get; }
        int Save();
    }
}
