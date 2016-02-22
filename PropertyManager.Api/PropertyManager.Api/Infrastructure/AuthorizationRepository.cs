using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PropertyManager.Api.Domain;
using PropertyManager.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace PropertyManager.Api.Infrastructure
{
    public class AuthorizationRepository : IDisposable
    {
        private UserManager<PropertyManagerUser> _userManager;

        private PropertyManagerDataContext _db;

        public AuthorizationRepository()
        {
            _db = new PropertyManagerDataContext();
            _userManager = new UserManager<PropertyManagerUser>(new UserStore<PropertyManagerUser>(_db));
        }
        public async Task<IdentityResult> RegisterUser(RegistrationModel model)
        {
            var propertyManagerUser = new PropertyManagerUser
            {
                UserName = model.Username,
                Email = model.EmailAddress
            };

            var result = await _userManager.CreateAsync(propertyManagerUser, model.Password);

            return result;
        }

        public async Task<PropertyManagerUser> FindUser(string username, string password)
        {
            return await _userManager.FindAsync(username, password);
        }

        public void Dispose()
        {
            _userManager.Dispose();
        }
    }
}