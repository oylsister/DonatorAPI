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
        public async Task<IActionResult> GetPurchaseHistories()
        {
            var purchaseHistories = await _purchaseHistory.GetPurchaseHistories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(purchaseHistories);
        }

        [HttpGet("{steamAuth}")]
        [ProducesResponseType(200, Type = typeof(PurchaseHistory))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetPurchaseHistoryByAuth(string steamAuth)
        {
            var purchaseHistory = await _purchaseHistory.GetUserPurchaseHistory(steamAuth);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if(purchaseHistory == null)
                return NotFound();

            return Ok(purchaseHistory);
        }

        [HttpPost("addPurchase")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddPurchaseHistory([FromBody] PurchaseHistory info)
        {
            if (info == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _purchaseHistory.AddPurchaseHistory(info);
            return CreatedAtAction(nameof(GetPurchaseHistoryByAuth), new { steamAuth = info.Auth }, info);
        }
    }
}
