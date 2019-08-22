using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;

    public class ManufacturerType : ObjectGraphType<Manufacturer>
    {
        public ManufacturerType()
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.PageSizeOptions);
            Field(m => m.CreatedOn);
        }
    }
}