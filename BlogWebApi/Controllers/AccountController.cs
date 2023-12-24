using BlogWebApi.Data.Dto.Account;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations;

namespace BlogWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager,
                                 SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost("Signup")]
        public async Task<AccountOutputDto> Signup(SignUpInputDto signUpInputDto)
        {
            try
            {
                var user = new IdentityUser()
                {
                    UserName = signUpInputDto.EmailAddress,
                    Email = signUpInputDto.EmailAddress
                };

                var signInRes = await _userManager.CreateAsync(user, signUpInputDto.Password);
                var signInRoleRes = await _userManager.AddToRoleAsync(user, signUpInputDto.UserRole);

                if (signInRoleRes.Succeeded &&
                    signInRes.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return new AccountOutputDto { Message = "ثبت نام با موفقیت انجام شد" };
                }
                throw new Exception();
            }
            catch (Exception ex)
            {
                return new AccountOutputDto { Message = "عملیات ثبت نام با خطا روبرو گردید" };
            }
        }

        [HttpPost("Signin")]
        public async Task<AccountOutputDto> Signin(SignInInputDto signInInputDto)
        {
            var result = await _signInManager.PasswordSignInAsync(signInInputDto.EmailAddress, signInInputDto.Password, signInInputDto.RememberMe, false);

            if (result.Succeeded)
            {
                return new AccountOutputDto { Message = "ورود با موفقیت انجام شد" };
            }

            return new AccountOutputDto { Message = "نام کاربری یا رمز عبور اشتباه می‌باشد" };
        }
    }
}
