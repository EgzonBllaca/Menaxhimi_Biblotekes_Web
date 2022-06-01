using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using static Menaxhimi_Biblotekes_Web.Areas.Identity.Pages.Account.LoginModel;

namespace Menaxhimi_Biblotekes_Web.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminManager : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AdminManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddAdmin(InputModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    IdentityResult roleresult = await _userManager.AddToRoleAsync(user, "Admin");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View();
        }
    }
}
