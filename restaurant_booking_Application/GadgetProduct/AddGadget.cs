using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using restaurant_booking_Application.Common;
using restaurant_booking_Infrastructure.Contexts;

namespace restaurant_booking_Application.GadgetProduct
{
    public class AddGadget
    {
        public class Query : IRequest<Response<string>>
        {
            public string ProductName { get; set; }
            public string ProductTitle { get; set; }
            public decimal ProductPrice { get; set; }
            public string ProductCategory { get; set; }
            public string ProductDescription { get; set; }
        }

        public class AddNewGadget : IRequestHandler<Query, Response<string>>
        {
            public readonly RbaContext _readwriteContext;
            public readonly IMapper _mapper;
            public AddNewGadget(RbaContext context, IMapper mapper)
            {
                _readwriteContext = context;
                _mapper = mapper;
            }
            public async Task<Response<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                List<string> dbCategories = _readwriteContext.GadgetProducts.Select(x => x.Category).Distinct().ToList();
                try
                {
                     var getCategory = dbCategories.FirstOrDefault(x =>
                        string.Equals(x, request.ProductCategory, StringComparison.OrdinalIgnoreCase));
                    _ = getCategory ?? throw new Exception("Invalid category name");
                    var query = _mapper.Map<restaurant_booking_Domain.Entities.GadgetProduct>(request);

                    query.Id = Guid.NewGuid().ToString();
                    query.DateCreated = DateTime.UtcNow;
                    query.UpdatedAt = DateTime.UtcNow;
                    await _readwriteContext.GadgetProducts.AddAsync(query);
                    await _readwriteContext.SaveChangesAsync(cancellationToken);
                    return Response<string>.Success("", query.Id);

                }
                catch (Exception e)
                {
                    return Response<string>.Fail(e.Message);
                }
            }
        }
    }
}
