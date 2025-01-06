using DonatorAPI.Data.Dto;
using DonatorAPI.Data.Entities;
using DonatorAPI.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace DonatorAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserInfoController(IUserInfoRepository useInfo) : Controller
{
    private readonly IUserInfoRepository _userInfo = useInfo;

    [HttpGet]
    [ProducesResponseType(200, Type = typeof(IEnumerable<UserInfo>))]
    public async Task<IActionResult> GetUserInfosAsync()
    {
        var userInfos = await _userInfo.GetUserInfos();

        return Ok(userInfos);
    }

    [HttpGet("{steamAuth}", Name = "GetUserInfoByAuth")]
    [ProducesResponseType(200, Type = typeof(UserInfo))]
    [ProducesResponseType(400)]
    public async Task<IActionResult> GetUserInfoByAuthAsync(string steamAuth)
    {
        if (!await _userInfo.IsUserInfoExist(steamAuth))
        {
            return NotFound();
        }

        var userInfo = await _userInfo.GetUserInfoByAuth(steamAuth);

        return Ok(userInfo);
    }

    [HttpPost("addUser")]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    public async Task<IActionResult> CreateUserInfoAsync([FromBody] UserInfo info)
    {
        if (await _userInfo.IsUserInfoExist(info.Auth))
        {
            return BadRequest("User already exists");
        }

        await _userInfo.CreateUserInfo(info);
        return CreatedAtAction("GetUserInfoByAuth", new { steamAuth = info.Auth }, info);
    }

    [HttpPut("{steamAuth}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> UpdateUserInfoAsync(string steamAuth, [FromBody] UserInfoDto info)
    {
        if (!await _userInfo.IsUserInfoExist(steamAuth))
        {
            return NotFound("User is not exists");
        }

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (!await _userInfo.UpdateUserInfo(info))
        {
            ModelState.AddModelError("", "Something went wrong updating User");
            return StatusCode(500, info.Auth);
        }

        return NoContent();
    }

    [HttpDelete("{steamAuth}")]
    [ProducesResponseType(400)]
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    public async Task<IActionResult> DeleteUserInfo(string steamAuth)
    {
        if (!await _userInfo.IsUserInfoExist(steamAuth))
        {
            return NotFound("User is not exists");
        }

        var user = await _userInfo.GetUserInfoByAuth(steamAuth);
        if (user is null)
        {
            return BadRequest("User is null!");
        }

        if (!await _userInfo.DeleteUserInfo(user))
        {
            ModelState.AddModelError("", "Something went wrong about deleting User");
        }

        return NoContent();
    }
}