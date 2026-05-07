using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using C__Advanced_Final_Project.Models;

namespace C__Advanced_Final_Project.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<User> userManager;
        private SignInManager<User> signInManager;
        public AccountController(UserManager<User> userMngr,
        SignInManager<User> signInMngr)
        {
            userManager = userMngr;
            signInManager = signInMngr;
        }
        // The Register(), LogIn(), and LogOut()methods go here
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new User { UserName = model.Username, FName = model.FName, LName = model.LName };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (model.IsDriver)
                    {
                        await userManager.AddToRoleAsync(user, "Driver");
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Driver");
                    }
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult LogIn(string returnURL = "")
        {
            var model = new Login { ReturnUrl = returnURL };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> LogIn(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                model.Username, model.Password,
                isPersistent: model.RememberMe,
                lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    // Redirect based on role
                    var user = await userManager.FindByNameAsync(model.Username);
                    if (await userManager.IsInRoleAsync(user, "Admin"))
                        return RedirectToAction("Index", "User");
                    if (await userManager.IsInRoleAsync(user, "Driver"))
                        return RedirectToAction("Index", "Driver");

                    if (!string.IsNullOrEmpty(model.ReturnUrl) &&
                    Url.IsLocalUrl(model.ReturnUrl))
                        return Redirect(model.ReturnUrl);

                    return RedirectToAction("Index", "Home");
                }
            }
            ModelState.AddModelError("", "Invalid username/password.");
            return View(model);
        }
        [HttpGet]
        public IActionResult ChangePassword()
        {
            var model = new ChangePasswordViewModel
            {
                Username = User.Identity?.Name ?? ""
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await userManager.FindByNameAsync(model.Username);
                var result = await userManager.ChangePasswordAsync(user,
                    model.OldPassword, model.NewPassword);
                if (result.Succeeded)
                {
                    TempData["message"] = "Password changed successfully";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                        ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        

    }
}
