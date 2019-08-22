using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType(IManufacturerService manufacturers)
        {
            Field(p => p.Id);
            Field(p => p.Name).Description("The Product Name");
            Field(p => p.FullDescription);
            Field(p => p.Published);
            Field(p => p.Deleted);
            Field(p => p.CreatedOn);
            Field<ManufacturerType>(
                "manufacturer",
                resolve: context => manufacturers.GetManufacturerByIdAsync(context.Source.ManufacturerId));
        }
    }
}