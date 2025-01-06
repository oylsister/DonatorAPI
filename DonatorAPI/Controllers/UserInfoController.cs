using DonatorAPI.Data;
using DonatorAPI.Dto;
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

        // .NET is a fucking pussy when having a name with "Async" behind can cause route issues, so we renamed it by remove Async on their ass.
        [HttpGet("{steamAuth}", Name = "GetUserInfoByAuth")]
        [ProducesResponseType(200, Type = typeof(UserInfo))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetUserInfoByAuthAsync(string steamAuth)
        {
            if(!await _userInfo.IsUserInfoExist(steamAuth))
                return NotFound();

            var userInfo = await _userInfo.GetUserInfoByAuth(steamAuth);

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
            return CreatedAtAction("GetUserInfoByAuth", new { steamAuth = info.Auth }, info);
        }

        [HttpPut("{steamAuth}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)] 
        [ProducesResponseType(404)]
        public async Task<IActionResult> UpdateUserInfoAsync(string steamAuth, [FromBody] UserInfoDto info)
        {
            if(info == null)
                return BadRequest(ModelState);

            if (!await _userInfo.IsUserInfoExist(steamAuth))
                return NotFound("User is not exists");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

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
                return NotFound("User is not exists");

            var user = await _userInfo.GetUserInfoByAuth(steamAuth);

            if (user == null)
                return BadRequest("User is null!");

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if(!await _userInfo.DeleteUserInfo(user))
            {
                ModelState.AddModelError("", "Something went wrong about deleting User");
            }

            return NoContent();
        }
    }
}