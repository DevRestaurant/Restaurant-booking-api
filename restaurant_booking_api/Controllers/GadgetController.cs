
using Microsoft.AspNetCore.Mvc;
using restaurant_booking_Application.Common;
using restaurant_booking_Application.GadgetProduct;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace restaurant_booking_api.Controllers
{
    public class GadgetController : ApiController
    {
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [Microsoft.AspNetCore.Mvc.HttpGet("all-product")]
        public async Task<ActionResult<Response<IEnumerable<GetGadgetAllProduct.Result>>>> GetAllGadget()
        {
            return await Mediator.Send(new GetGadgetAllProduct.Query());
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost("add-product")]
        [ResponseType(typeof(Response<string>))]
        public async Task<ActionResult<Response<string>>> AddGadget([FromUri] AddGadget.Query query)
        {
            return await Mediator.Send(query);
        }
    }
}
