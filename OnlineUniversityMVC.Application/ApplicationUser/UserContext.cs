using Microsoft.AspNetCore.Http;
using OnlineUniversityMVC.Application.Services;
using OnlineUniversityMVC.Application.Services.Interfaces;
using OnlineUniversityMVC.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineUniversityMVC.Application.ApplicationUser
{
    public class UserContext
    {

        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public UserContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserContext(IHttpContextAccessor httpContextAccessor, IUserService userService)
        {
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }
        public CurrentUser GetCurrentUser()
        {
            var currentUser = _httpContextAccessor.HttpContext?.User;
            if (currentUser == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }

            if (currentUser.Identity == null || !currentUser.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = currentUser.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
            var email = currentUser.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;


            return new CurrentUser(id, email);

        }

        public string GetCurrentUserRole()
        {
            var userContext = _httpContextAccessor.HttpContext?.User;
            if (userContext == null)
            {
                throw new InvalidOperationException("Context user is not present");
            }

            if (userContext.Identity == null || !userContext.Identity.IsAuthenticated)
            {
                return null;
            }

            var id = userContext.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;

            var user = _userService.GetById(id);
            var role = _userService.GetRoleName(user);

            return role;

        }
    }
}
