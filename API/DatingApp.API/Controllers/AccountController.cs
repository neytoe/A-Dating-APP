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

        public AccountController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> Register (RegisterUserDto newuser)
        {
            if (await _userRepository.userExists(newuser.Username)) return BadRequest("Username is taken");

            using var hmac = new HMACSHA512();

            var user = _mapper.Map<AppUser>(newuser);

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(newuser.Password));
            user.PasswordSalt = hmac.Key;

           await _userRepository.Save(user);
            return user;
        }
    }
}
