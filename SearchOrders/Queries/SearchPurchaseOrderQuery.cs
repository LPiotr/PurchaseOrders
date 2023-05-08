using MediatR;
using SearchOrders.Models;
using SearchOrders.Repositories;

namespace SearchOrders.Queries
{
    public class SearchPurchaseOrderQuery : IRequest<List<PurchaseOrder>> 
    {
        public string OrderNumber { get; set; }
        public DateTime? OrderDateFrom { get; set; }
        public DateTime? OrderDateTo { get; set; }
        public bool IncludeCustomers { get; set; }
        //List - to be added
    }

    public class SearchOrderHandler : IRequestHandler<SearchPurchaseOrderQuery, List<PurchaseOrder>>
    {
        private readonly IRepository _repository;

        public SearchOrderHandler(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PurchaseOrder>> Handle(SearchPurchaseOrderQuery request, CancellationToken cancellationToken)
        {
            var purchaseOrders = _repository.GetOrders();

            if (request.OrderNumber != null)
            {
                purchaseOrders = (List<PurchaseOrder>)purchaseOrders.Where(o => o.Number == request.OrderNumber);
            }
            if (request.OrderDateFrom.HasValue)
            {
                purchaseOrders = purchaseOrders.Where(o => o.OrderDate >= request.OrderDateFrom.Value).ToList();
            }
            if (request.OrderDateTo.HasValue)
            {
                purchaseOrders = purchaseOrders.Where(o => o.OrderDate <= request.OrderDateTo.Value).ToList();
            }
            return purchaseOrders;
        }
    }
}
