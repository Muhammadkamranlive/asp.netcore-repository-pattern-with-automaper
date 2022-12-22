using AutoMapper;
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
        public AccountController(UserManager<ApiUser> userManager, ILogger<AccountController> logger, IMapper mapper)
        {
            this.userManager = userManager;
            //this.signInManager = signInManager;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        [Route("register")]
        [ProducesResponseType(StatusCodes.Status202Accepted)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register([FromBody] UserDTOS userDTO)

        {
            logger.LogInformation($"Registration Attempt for {userDTO.Email} ");
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var user = mapper.Map<ApiUser>(userDTO);
                user.UserName = userDTO.Email;
                var result = await userManager.CreateAsync(user, userDTO.Password);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(error.Code, error.Description);
                    }
                    return BadRequest(ModelState);
                }
                await userManager.AddToRolesAsync(user, userDTO.Roles);
                return Accepted();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Something Went Wrong in the {nameof(Register)}");
                return Problem($"Something Went Wrong in the {nameof(Register)}", statusCode: 500);
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
