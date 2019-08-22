using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Services;
    using GraphQLDemo.Services.Interfaces;

    public class ProductsQuery : ObjectGraphType<object>
    {
        public ProductsQuery(ProductService products)
        {
            Name = "ProductsQuery";
            Field<ListGraphType<ProductType>>("products", resolve: context => products.GetProductsAsync());
        }
    }
}