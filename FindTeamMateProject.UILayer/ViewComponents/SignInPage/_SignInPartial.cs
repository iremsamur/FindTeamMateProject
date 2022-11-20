using FindTeamMateProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FindTeamMateProject.UILayer.ViewComponents
{
    public class _SignInPartial:ViewComponent
    {
        private readonly SignInManager<AppUser> _signInManager;

        public _SignInPartial(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }
        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync(AppUser appUser)
        {

            var result = await _signInManager.PasswordSignInAsync(appUser.UserName, appUser.PasswordHash, false, true);

            if (result.Succeeded)
            {
                return View("_SignInPartial");
            }

            return View();
        }

    }
}
