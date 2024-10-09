using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace shop_app.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //Register
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        //Register
        [HttpPost]
        public async Task<IActionResult> Create(string email, string password)
        {
            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email or password are error!");
            }
            var newUser = new IdentityUser
            {
                Email = email,
                UserName = email,
                EmailConfirmed = true //Imitation check email
            };
            var result = await _userManager.CreateAsync(newUser, password);
            if(result.Succeeded)
            {
                //return Ok("User is registered successfully");
                return RedirectToAction("Index", "Home");
            }
            return BadRequest("Error register!");
        }
        //auth
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            Console.WriteLine($"Login: {email}, password: {password}");
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                return BadRequest("Email or password are error!");
            }
            var result = await _signInManager.PasswordSignInAsync(
                email, 
                password,
                isPersistent: false,
                lockoutOnFailure: false
                );
            if (result.Succeeded)
            {
                //HttpContext.Session.SetString("login", email);
                //return Ok("The user is authorized ...");
                return RedirectToAction("Index", "Home");
            }
            return BadRequest("Error auth ...");
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
