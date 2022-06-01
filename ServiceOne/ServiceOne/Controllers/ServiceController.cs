using Application.Service.Queries.GetData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceOne.Controllers
{
    public class ServiceController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetData/{id}")]
        public async Task<ActionResult<GetDataResponse>> GetData(int id)
        {
            try
            {
                return await Mediator.Send(new GetDataRequest { Id = id });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.ToString() });
            }
        }
    }
}