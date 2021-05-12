using AutoMapper;
using DatingApp.Core;
using DatingApp.Core.DTOs;
using DatingApp.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public AccountController(IUserRepository userRepository, IMapper mapper, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register (RegisterUserDto newuser)
        {
            if (await _userRepository.userExists(newuser.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = _mapper.Map<AppUser>(newuser);

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(newuser.Password));
            user.PasswordSalt = hmac.Key;

           await _userRepository.Save(user);

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.Createtoken(user)
            };
        }

        [HttpPost("Login")]
        public async Task<ActionResult<UserDto>> Login (LoginDto loginUser)
        {
            var user = await _userRepository.GetUser(loginUser.Username);

            if (user == null) return Unauthorized("Invalid Username");
            //get the password salt of the user
            using var hmac = new HMACSHA512(user.PasswordSalt);

            //use the salt gotten to get the password hash of the user that wnats to login
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginUser.Password));

            //compare the password hash of the user in the database with the one for the user that wants to login 
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid Password");

            }

            return new UserDto
            {
                Username = user.UserName,
                Token = _tokenService.Createtoken(user)
            }; 
        }
    }
}
