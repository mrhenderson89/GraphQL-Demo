using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class PriorityType : ObjectGraphType<PriorityDto>
    {
        public PriorityType(IPriorityService priorityService)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field(m => m.Description);
            Field(m => m.SortOrder);
            Field(m => m.IsDeleted);
        }
    }
}
