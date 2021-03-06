using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface IUserRepository: IRepository<AppUser>
    {
        Task<bool> userExists(string username);

        Task<AppUser> GetUser(string username);
    }
}
