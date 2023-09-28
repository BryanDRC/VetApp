using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using VetAppApi.Entities;
using VetAppApi.Models;

namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthModel? _authModel;

        public AuthController(AuthModel authModel)
        {
            _authModel = authModel;
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<UserObj> Login(UserObj userObj)
        {
            try
            {
                var data = _authModel.Login(userObj);
                return data != null ? Ok(data) : BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest("Se produjo un error al iniciar sesión. " + ex);
            }
        }
    }
}