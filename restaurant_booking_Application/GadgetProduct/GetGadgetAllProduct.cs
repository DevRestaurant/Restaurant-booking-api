using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using restaurant_booking_Application.Common;

namespace restaurant_booking_Application.GadgetProduct
{
    public class GetGadgetAllProduct
    {
        public class Query : IRequest<Response<Model>>
        {

        }

        public class Model
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
        }
    }
}
