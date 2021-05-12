using AutoMapper;
using DatingApp.Core;
using DatingApp.Core.DTOs;
using DatingApp.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAllUsers")]
        [AllowAnonymous]
        public async Task<IEnumerable<AppUser>> GetUsers()
        {
            var users = await _userRepository.FindAll();
            return users;

        }

        [HttpPost("CreateUser")]
        public async Task<AppUser> CreateUsers(createUserDto user)
        {
            var newuser = _mapper.Map<AppUser>(user);
            await _userRepository.Save(newuser);
            return newuser;

        }

        [Authorize]

        [HttpGet("{id}")]
        public async Task<AppUser> GetUser(int id)
        {
            var user = await _userRepository.Find(id);
            return user;
        }
}
}
