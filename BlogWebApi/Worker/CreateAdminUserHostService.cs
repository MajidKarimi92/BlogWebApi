
using BlogWebApi.Data.Dto.Account;
using Microsoft.AspNetCore.Identity;

namespace BlogWebApi.Worker
{
    public class CreateAdminUserHostService : IHostedService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public CreateAdminUserHostService(UserManager<IdentityUser> userManager,
                                          SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public  Task StartAsync(CancellationToken cancellationToken)
        {

            var adminUser = _userManager.FindByNameAsync("Admin");
            if (adminUser == null) return Task.CompletedTask;
            var user = new IdentityUser()
             {
                 UserName = "Admin"
             };
            var signInResult = _userManager.CreateAsync(user, "Admin123");
            var userRoleResult = _userManager.AddToRoleAsync(user, "Administrator");
            if (signInResult.Result.Succeeded &&
                userRoleResult.Result.Succeeded)
            {
                _signInManager.SignInAsync(user, isPersistent: false);
                return Task.CompletedTask;
            }
            return null;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
