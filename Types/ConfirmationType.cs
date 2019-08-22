using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL;
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class ConfirmationType : ObjectGraphType<ConfirmationDto>
    {
        public ConfirmationType(IConfirmationService confirmationService)
        {
            Field(m => m.Id).Name("Id").Description("ConfirmationId");
            Field(m => m.Name).Name("Name").Description("Confirmation Name");
            Field(m => m.Description).Name("Description").Description("Confirmation Description");
            Field(m => m.SortOrder).Name("SortOrder").Description("Confirmation Sort Order");
            Field(m => m.IsDeleted).Name("IsDeleted").Description("Confirmation Is Deleted");
        }
    }
}
