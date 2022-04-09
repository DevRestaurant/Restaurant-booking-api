using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using restaurant_booking_Application.Common;
using restaurant_booking_Application.AuthCQRS;

namespace restaurant_booking_api.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet("current-user")]
        public async Task<Response<GetUser.Model>> Getuser()
        {
            var userId = HttpContext.User.FindFirst(x => x.Type == ClaimTypes.NameIdentifier).Value;
            var command = new GetUser.Query
            {
                Id = userId
            };
            return await Mediator.Send(command);
        }
    }
}
