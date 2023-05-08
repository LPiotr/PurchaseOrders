using MediatR;
using Microsoft.AspNetCore.Mvc;
using SearchOrders.Models;
using SearchOrders.Queries;

namespace SearchOrders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
        #region private fields

        private readonly IMediator _mediator;

        #endregion

        #region constructor
        public PurchaseOrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #endregion

        #region methods

        [HttpGet]
        public async Task<ActionResult<List<PurchaseOrder>>> SearchPurchaseOrders([FromQuery] SearchPurchaseOrderQuery query)
        {
            var orders = await _mediator.Send(query);


            return orders;
        }

        #endregion
    }
}
