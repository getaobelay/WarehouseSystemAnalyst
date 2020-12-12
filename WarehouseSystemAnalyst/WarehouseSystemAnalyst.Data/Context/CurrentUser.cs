using Microsoft.AspNetCore.Http;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using WarehouseSystemAnalyst.Data.DataContext;

namespace WarehouseSystemAnalyst.Data.Context
{
    public class CurrentUser : ICurrentUser
    {
        public CurrentUser(IHttpContextAccessor contextAccessor)
        {
            ContextAccessor = contextAccessor;
        }

        public IHttpContextAccessor ContextAccessor { get; }

        /*public bool IsAuthenticated()
        {
            return ContextAccessor.HttpContext.User.Identity.IsAuthenticated;
        }

        public IEnumerable<Claim> GetClaims()
        {
            return ContextAccessor.HttpContext.User.Claims;
        }

        public string GetUsername()
        {
            return ContextAccessor.HttpContext.User.Identity.Name;
        }*/

        public bool IsAuthenticated()
        {
            return true;
        }

        public IEnumerable<Claim> GetClaims()
        {
            return ContextAccessor.HttpContext.User.Claims;
        }

        public string GetUsername()
        {
            return "getao";
        }
    }
}
