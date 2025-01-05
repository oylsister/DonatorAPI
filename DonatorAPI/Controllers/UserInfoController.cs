using DonatorAPI.Data;
using DonatorAPI.Interfaces;
using DonatorAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DonatorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : Controller
    {
        private readonly IUserInfo _userInfo;
        private readonly DataContext _dataContext;

        public UserInfoController(IUserInfo useInfo, DataContext dataContext)
        {
            _userInfo = useInfo;
            _dataContext = dataContext;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserInfo>))]
        public async Task<IActionResult> GetUserInfosAsync()
        {
            var userInfos = await _userInfo.GetUserInfos();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userInfos);
        }

        [HttpGet("{steamAuth}")]
        [ProducesResponseType(200, Type = typeof(UserInfo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserInfoByAuthAsync(string steamAuth)
        {
            if(!await _userInfo.IsUserInfoExist(steamAuth))
                return NotFound();

            var userInfo = _userInfo.GetUserInfoByAuth(steamAuth);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userInfo);
        }

        [HttpPost("addUser")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CreateUserInfoAsync([FromBody] UserInfo info)
        {
            if (info == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (await _userInfo.IsUserInfoExist(info.Auth))
                return BadRequest("User already exists");

            await _userInfo.CreateUserInfo(info);
            return CreatedAtAction(nameof(GetUserInfoByAuthAsync), new { steamAuth = info.Auth }, info);
        }
    }
}