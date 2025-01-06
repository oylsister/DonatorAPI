using DonatorAPI.Data.Entities;
using DonatorAPI.Data.Repositories.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DonatorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PurchaseHistoryController(
    IPurchaseHistoryRepository purchaseHistory
    ) : Controller
{
    private readonly IPurchaseHistoryRepository _purchaseHistory = purchaseHistory;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<Purchase>))]
    public async Task<IActionResult> GetPurchaseHistories()
    {
        var purchaseHistories = await _purchaseHistory.GetPurchaseHistories();

        return Ok(purchaseHistories);
    }

    [HttpGet("{steamAuth}")]
    [ProducesResponseType(200, Type = typeof(Purchase))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetPurchaseHistoryByAuth(string steamAuth)
    {
        var purchaseHistory = await _purchaseHistory.GetUserPurchaseHistory(steamAuth);

        return purchaseHistory is null ? NotFound() : Ok(purchaseHistory);
    }

    [HttpPost("addPurchase")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> AddPurchaseHistory([FromBody] Purchase info)
    {
        await _purchaseHistory.CreatePurchaseHistory(info);
        return CreatedAtAction(nameof(GetPurchaseHistoryByAuth), new { steamAuth = info.Auth }, info);
    }
}
