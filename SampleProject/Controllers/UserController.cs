using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Database;
using SampleProject.Dtos;
using SampleProject.Models;
using SampleProject.Services;

namespace SampleProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserServices _userService;
        private IMapper _mapper;

        public UserController(IUserServices userService,
            IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("getusers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            var userDtos = _mapper.Map<IList<DataDto>>(users);

            return Ok(userDtos);
        }

        [HttpGet("getusers/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [AllowAnonymous]
        [HttpPost("adduser")]
        public IActionResult CreateUser(DataDto userModel)
        {
            try
            {
                var user = _mapper.Map<Data>(userModel);
                var adduser = _userService.CreateUser(user, userModel.Password);
                if (adduser == null)
                    return BadRequest(new { message = "Cannot be empty" });

                return Ok(userModel);
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new
                {
                    message = ex.Message
                });
            }
        }

        [HttpPost("edituser/{id}")]
        public IActionResult EditUser(DataDto userModel)
        {
            var user = _mapper.Map<Data>(userModel);
            return Ok(_userService.EditUser(user));
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}