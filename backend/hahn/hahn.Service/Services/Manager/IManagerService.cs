using hahn.Domain.Entities;
using hahn.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Service.Services
{
    public interface IManagerService
    {
        Task<ResponseModel<IdentityResult>> AddAsync();
        
    }
}
