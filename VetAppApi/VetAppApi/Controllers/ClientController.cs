using Microsoft.AspNetCore.Mvc;
using VetAppApi.Entities;
using VetAppApi.Models;


namespace VetAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ClientModel _clientModel;

        public ClientController(IConfiguration configuration, ClientModel clientModel)
        {
            _configuration = configuration;
            _clientModel = clientModel;
        }

        [HttpGet]
        [Route("GetAllClients")]
        public ActionResult<List<ClientObj>> GetAllClients()
        {
            return _clientModel.GetListClients();
        }

        [HttpPost]
        [Route("RegisterClient")]
        public ActionResult RegisterClient(ClientObj clientObj)
        {
            return _clientModel.RegisterClient(clientObj) > 0 ? Ok() : BadRequest();
        }

        [HttpPut]
        [Route("UpdateClient")]
        public ActionResult UpdateClient(ClientObj clientObj)
        {
            try
            {
                if (clientObj == null)
                    return NoContent();

                var result = _clientModel.UpdateClient(clientObj);
                if (result > 0)
                {
                    return Ok(clientObj);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteClient")]
        public ActionResult DeleteClient(ClientObj clientObj)
        {
            return (_clientModel.DeleteClient(clientObj) > 0) ? Ok() : BadRequest();
        }


    }
}