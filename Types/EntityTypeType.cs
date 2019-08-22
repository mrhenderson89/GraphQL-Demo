using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class EntityTypeType : ObjectGraphType<EntityTypeDto>
    {
        public EntityTypeType(IEntityTypeService entityTypeService)
        {
            Field(m => m.Id).Name("Id").Description("EntityTypeId");
            Field(m => m.Name).Name("Name").Description("EntityType Name");
            Field(m => m.CssClass).Name("CssClass").Description("EntityType CSS Class");
            Field(m => m.SvgIcon).Name("SvgIcon").Description("EntityType SVG Icon");
        }
    }
}
