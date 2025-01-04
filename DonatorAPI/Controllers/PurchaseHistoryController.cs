using DonatorAPI.Data;
using DonatorAPI.Interfaces;
using DonatorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DonatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseHistoryController : Controller
    {
        private readonly IPurchaseHistory _purchaseHistory;
        private readonly DataContext _dataContext;

        public PurchaseHistoryController(IPurchaseHistory purchaseHistory, DataContext dataContext)
        {
            _purchaseHistory = purchaseHistory;
            _dataContext = dataContext;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PurchaseHistory>))]
        public IActionResult GetPurchaseHistories()
        {
            var purchaseHistories = _purchaseHistory.GetPurchaseHistories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(purchaseHistories);
        }

        [HttpGet("{steamAuth}")]
        [ProducesResponseType(200, Type = typeof(PurchaseHistory))]
        [ProducesResponseType(400)]
        public IActionResult GetPurchaseHistoryByAuth(string steamAuth)
        {
            var purchaseHistory = _purchaseHistory.GetUserPurchaseHistory(steamAuth);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(purchaseHistory == null)
                return NotFound();

            return Ok(purchaseHistory);
        }
    }
}
