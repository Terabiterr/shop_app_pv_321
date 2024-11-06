using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using shop_app.Models;

namespace shop_app.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIUserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public APIUserController(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        //Register
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(new { message = "The model is invalid ..." });
            }
            var newUser = new IdentityUser
            {
                Email = model.Email,
                UserName = model.Email,
                EmailConfirmed = true //Imitation check email
            };
            var result = await _userManager.CreateAsync(newUser, model.Password);
            if (result.Succeeded)
            {
                return Ok(new { message = "Registered successfully ..." });
            }
            return BadRequest(result.Errors);
        }
        [HttpPost("auth")]
        public async Task<IActionResult> Auth([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { message = "The model is invalid ..." });
            }
            var result = await _signInManager.PasswordSignInAsync(
                model.Email,
                model.Password,
                isPersistent: false,
                lockoutOnFailure: false
                );
            if (result.Succeeded)
            {
                return Ok(new { message = "The user is authorized ..." });
            }
            return BadRequest(new { message = "Invalid email or password ..." });
        }
        [HttpPost]
        public async Task<IActionResult> AccessDenied()
        {
            return BadRequest("Access Denied");
        }
    }
}
