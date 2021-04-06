using Business.Apstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Wep.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        IUserService _userServiceİ;
        public UserController(IUserService userService)
        {
            _userServiceİ = userService;
        }

        [HttpPost("update")]
        public IActionResult Add(User user)
        {
            var result =_userServiceİ.Update(user);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getbyuserId")]
        public IActionResult GetByUserId(int userId)
        {
            var result = _userServiceİ.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getrentalbyuserid")]
        public IActionResult GetRentalDetailByUserId(int userId)
        {
            var result = _userServiceİ.GetRentalByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }


    }
}
