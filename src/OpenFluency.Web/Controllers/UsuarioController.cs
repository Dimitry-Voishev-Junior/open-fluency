    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Mvc;
    using OpenFluency.Web.Models.Usuario;
    using System.Security.Claims;

    namespace OpenFluency.Web.Controllers
    {
        public class UsuarioController : Controller
        {
            [Route("login")]
            public IActionResult Login()
            {
                return View();
            }

            [HttpPost]
            [Route("Login")]
            public IActionResult Login(LoginViewModel model)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }

                var claims = new List<Claim>
                {
                    new (ClaimTypes.NameIdentifier, model.Usuario!)
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var propeties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    IsPersistent = model.LembrarMe
                };

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), propeties);

                return RedirectToAction("Index", "Home");
            }
        }
    }
