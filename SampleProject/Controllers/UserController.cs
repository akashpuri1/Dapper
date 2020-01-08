using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
            var userDtos = _mapper.Map<IList<UserDto>>(users);

            return Ok(userDtos);
        }

        [HttpGet("getusers/{id}")]
        public IActionResult GetUserById(int id)
        {
            return Ok(_userService.GetUserById(id));
        }

        [AllowAnonymous]
        [HttpPost("adduser")]
        public IActionResult CreateUser(User userModel)
        {
            try
            {
                var adduser = _userService.CreateUser(userModel, userModel.Password);
                if (adduser == null)
                    return BadRequest(new { message = "Cannot be empty" });

                return Ok(new
                {
                    ID = adduser.ID,
                    Title = adduser.Title,
                    FirstName = adduser.FirstName,
                    LastName = adduser.LastName,
                    Email = adduser.Email,
                    Password = adduser.Password
                });
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
        public IActionResult EditUser(User userModel)
        {
            return Ok(_userService.EditUser(userModel));
        }

        [HttpPost("delete/{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userService.DeleteUser(id);
            return Ok();
        }
    }
}