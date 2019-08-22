using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class ImageType : ObjectGraphType<ImageDto>
    {
        public ImageType(IImageService imageService)
        {
            Field(m => m.ImageId).Name("ImageId").Description("ImageId");
            Field(m => m.Name).Name("Name").Description("Image Name");
            Field(m => m.ImageUrl).Name("ImageUrl").Description("URL of the Image");
        }
    }
}
