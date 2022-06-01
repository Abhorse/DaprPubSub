using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceTwo.Application.Service.Commands.UpdateData;
using Dapr;

namespace ServiceTwo.ServiceTwo.Controllers
{
    public class ServiceController : ApiControllerBase
    {
        [Topic("pubsub", "UpdateData")]
        [HttpPost(nameof(UpdateData))]
        public async Task<ActionResult<UpdateDataResponseModel>> UpdateData([FromBody] UpdateDataRequestModel request)
        {
            try
            {
                return await Mediator.Send(request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest(new { Error = ex.ToString() });
            }
        }
    }
}