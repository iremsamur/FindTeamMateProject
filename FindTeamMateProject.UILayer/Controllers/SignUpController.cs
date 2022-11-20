using FindTeamMateProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FindTeamMateProject.UILayer.Controllers
{
    public class SignUpController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public SignUpController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser, appUser.PasswordHash);//bu metod yeni bir kullanıcı değeri oluşturacak. Bir kullanıcı ve şifre istiyor
            //await burada beklemeden çalışmasını sağlar.
            bool check = result.Succeeded;
            if (result.Succeeded)
            {
                ViewBag.registerIsSucceeded = true;
                return RedirectToAction("Login", "SignIn");
            }


            return View();
        }

    }
}
