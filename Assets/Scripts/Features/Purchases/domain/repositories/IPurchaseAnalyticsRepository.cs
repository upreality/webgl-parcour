namespace Features.Purchases.domain.repositories
{
    public interface IPurchaseAnalyticsRepository
    {
        public void SendPurchasedEvent(long purchaseId);
    }
}