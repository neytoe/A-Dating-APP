using API;
using API.Data;
using DatingApp.Core;
using DatingApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Services
{
    public class UserRepository : BaseRepository<AppUser>, IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
