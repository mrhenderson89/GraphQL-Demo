using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class UserRoleType : ObjectGraphType<UserRole>
    {
        public UserRoleType(IUsersService userService, IRoleService roleService)
        {
            Field(i => i.UserId);

            Field<UserType, UserDto>().Name("User").ResolveAsync(ctx => userService.GetUserByIdAsync(ctx.Source.UserId));
            
            Field(i => i.RoleId);

            Field<RoleType, RoleDto>().Name("Role").ResolveAsync(ctx => roleService.GetRoleByIdAsync(ctx.Source.RoleId));

        }
    }
}
