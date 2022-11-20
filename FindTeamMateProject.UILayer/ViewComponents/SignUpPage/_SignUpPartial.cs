using FindTeamMateProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FindTeamMateProject.UILayer.ViewComponents.SignUpPage
{
    public class _SignUpPartial : ViewComponent
    {
        private readonly UserManager<AppUser> _userManager;

        public _SignUpPartial(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return View();
        }

        [HttpPost]
        public async Task<IViewComponentResult> InvokeAsync(AppUser appUser)
        {

            var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);//bu metod yeni bir kullanıcı değeri oluşturacak. Bir kullanıcı ve şifre istiyor
            //await burada beklemeden çalışmasını sağlar.
            bool check = result.Succeeded;
            if (result.Succeeded)
            {
                ViewBag.registerIsSucceeded = true;
                return View("_SignInPartial");

            }


            return View();
        }
    }
}
