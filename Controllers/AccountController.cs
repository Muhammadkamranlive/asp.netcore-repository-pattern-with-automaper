using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trevoir.Data;
using Trevoir.DTOS;
namespace Trevoir.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly SignInManager<ApiUser> signInManager;
        private readonly UserManager<ApiUser> userManager;
        private readonly IMapper mapper;
        private readonly ILogger<AccountController> logger;
        public AccountController(UserManager<ApiUser> userManager, ILogger<AccountController> logger,IMapper mapper )
        {
            this.userManager = userManager;
            //this.signInManager = signInManager;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserDTOS userDTOS)

        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = mapper.Map<ApiUser>(userDTOS);
                user.UserName = userDTOS.Email;
                var result = await userManager.CreateAsync(user,userDTOS.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)    
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRolesAsync(user, userDTOS.Roles);
                return Accepted();
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        //[HttpPost]
        //[Route("Login")]
        //public async Task<IActionResult> Lgin([FromBody] UserLoginDTO userLgoinDto)

        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    try
        //    {
        //        var user = mapper.Map<ApiUser>(userLgoinDto);
        //        var result = await signInManager.PasswordSignInAsync (userLgoinDto.Email,userLgoinDto.Password,false,false);
        //        if (!result.Succeeded)
        //        {
        //            return BadRequest("Something bad Happend");
        //        }
        //        return Accepted();
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, ex.Message);
        //    }
        
       
    //}

       
    
    }
}
