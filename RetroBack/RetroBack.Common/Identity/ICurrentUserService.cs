﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetroBack.Common.Identity
{
    public interface ICurrentUserService
    {
        Task<CurrentUser> GetCurrentUser();
    }
}
