using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using restaurant_booking_Application.Common;
using restaurant_booking_Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace restaurant_booking_Application.AuthCQRS
{
    public class GetUser
    {
        public class Query : IRequest<Response<Model>>
        {
            public string Id { get; set; }
        }

        public class Model
        {
            public string Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Avatar { get; set; }
            public  string Email { get; set; }
            public string PhoneNumber { get; set; }
        }

        public class CurrentUserQuery : IRequestHandler<Query, Response<Model>>
        {
            private readonly UserManager<AppUsers> _usermanager;
            private readonly IMapper _mapper;


            public CurrentUserQuery(UserManager<AppUsers> usermanager, IMapper mapper)
            {
                _usermanager = usermanager;
                _mapper = mapper;
            }
            public async Task<Response<Model>> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = _usermanager.Users?.FirstOrDefault(x => x.Id == request.Id);
                var userMapped = _mapper.Map<Model>(user);
                return Response<Model>.Success("Current user retrieved successfully", userMapped);
            }
        }
    }
}
