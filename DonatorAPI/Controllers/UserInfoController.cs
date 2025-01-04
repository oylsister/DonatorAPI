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
        public IActionResult GetUserInfos()
        {
            var userInfos = _userInfo.GetUserInfos();
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userInfos);
        }
    }
}