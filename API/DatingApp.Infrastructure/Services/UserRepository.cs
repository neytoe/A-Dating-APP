using API;
using API.Data;
using DatingApp.Core;
using DatingApp.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Infrastructure.Services
{
    public class UserRepository : BaseRepository<AppUser>, IUserRepository
    {
       
        private readonly DbSet<AppUser> entitySet;
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
           
            entitySet = dataContext.Set<AppUser>();
        }

        public async Task<bool> userExists(string username)
        {
            return await entitySet.AnyAsync(x => username.ToLower() == x.UserName.ToLower());
        }

        public async Task<AppUser> GetUser (string username)
        {
            return await entitySet.SingleOrDefaultAsync(x => x.UserName.ToLower() == username.ToLower());
        }
    }
}
