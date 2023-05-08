using SearchOrders.Models;

namespace SearchOrders.Repositories
{
    public interface IRepository
    {
        List<PurchaseOrder> GetOrders();
    }
}
