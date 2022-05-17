using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using restaurant_booking_Application.Common;
using restaurant_booking_Domain.Entities;

namespace restaurant_booking_Application
{
    public class AddImageToDocument
    {
        public class Query : IRequest<Response<string>>
        {
            public IFormFile image { get; set; }
            public string Id { get; set; }
        }

        public class AddImage : IRequestHandler<Query, Response<string>>
        {
            private readonly IConfiguration _config;
            private readonly Cloudinary _cloudinary;
            private readonly UserManager<AppUsers> _userManager;
            public AddImage(IConfiguration config, Cloudinary cloudinary, UserManager<AppUsers> userManager)
            {
                _config = config;
                _cloudinary = cloudinary;
                _userManager = userManager;
            }

            public async Task<Response<string>> Handle(Query request, CancellationToken cancellationToken)
            {
                try
                {
                    long pictureSize = Convert.ToInt64(_config["PhotoSettings:Size"]);
                    if (request.image.Length > pictureSize)
                    {
                        throw new Exception("File size exceeded");
                    }

                    bool pictureFormat = false;



                    var listOfImageExtensions = new List<string>() {".jpg", ".png", ".jpeg"};

                    foreach (var item in listOfImageExtensions)
                    {
                        if ((request.image.FileName.ToLower().EndsWith(item)))
                        {
                            pictureFormat = true;
                            break;
                        }
                    }

                    if (pictureFormat == false)
                    {
                        throw new Exception("File format not supported");
                    }

                    var uploadResult = new ImageUploadResult();

                    using var imageStream = request.image.OpenReadStream();

                    string filename = Guid.NewGuid().ToString() + request.image.FileName;

                    uploadResult = await _cloudinary.UploadAsync(new ImageUploadParams()
                    {
                        File = new FileDescription(filename + Guid.NewGuid().ToString(), imageStream),
                        PublicId = "gadget product/" + filename,

                        //Transformation = new Transformation().Crop("thumb").Gravity("face")
                    });

                    var imageUrl = uploadResult.Url.ToString();

                    try
                    {
                        var getUser = _userManager.Users.FirstOrDefault(x => x.Id == request.Id);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                        throw;
                    }


                    return Response<string>.Success("", uploadResult.Url.ToString());
                }
                catch (Exception e)
                {
                    return Response<string>.Fail(e.Message);
                }
            }
        }
    }
}
