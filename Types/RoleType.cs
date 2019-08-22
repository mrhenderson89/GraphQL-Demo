using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class RoleType : ObjectGraphType<RoleDto>
    {
        public RoleType(IUserRoleService userRoleService)
        {
            Field(m => m.Id);
            Field(m => m.Name);
            Field<ListGraphType<UserRoleType>, IEnumerable<UserRole>>().Name("Users").ResolveAsync(
                ctx => { return userRoleService.GetUserRolesByRoleIdAsync(ctx.Source.Id); });
        }
    }
}
