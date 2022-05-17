using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using restaurant_booking_Application.Common;
using restaurant_booking_Domain.Entities;
using restaurant_booking_Infrastructure.Contexts;

namespace restaurant_booking_Application.GadgetProduct
{
    
    public class GetGadgetAllProduct
    {
        public class Query : IRequest<Response<IEnumerable<Result>>>{ }

        public class Result
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Title { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
        }

        public class GetAllProducts : IRequestHandler<Query, Response<IEnumerable<Result>>>
        {
            private readonly RbaContext _readwriteRbaContext;
            private readonly IMapper _mapper;
            public GetAllProducts(IMapper mapper, RbaContext context)
            {
                _mapper = mapper;
                _readwriteRbaContext = context;
            }
            public async Task<Response<IEnumerable<Result>>> Handle(Query request, CancellationToken cancellationToken)
            {
                var allGadgets = await _readwriteRbaContext.GadgetProducts
                    .Select(x => new restaurant_booking_Domain.Entities.GadgetProduct()
                    {
                        Id = x.Id,
                        ProductName = x.ProductName,
                        Title = x.Title,
                        Price = x.Price,
                        Category = x.Category,
                        Image = x.Image,
                        Description = x.Description
                    })
                    .ToListAsync();
                var gadgetMapped = _mapper.Map<IEnumerable<Result>>(allGadgets);
                return Response<IEnumerable<Result>>.Success("product retrieved successfully", gadgetMapped);
            }
        }
    }
}
