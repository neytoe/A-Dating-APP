﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatingApp.Core.Interfaces
{
    public interface ITokenService
    {
        string Createtoken(AppUser user);
    }
}
