using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services;
    using GraphQLDemo.Services.Interfaces;

    public class UserType : ObjectGraphType<UserDto>
    {
        public UserType(IUserRoleService userRoleService, IImageService imageService, INotificationUserService notificationUserService)
        {
            Field(m => m.Id);
            Field(m => m.Title);
            Field(m => m.FirstName);
            Field(m => m.LastName);
            Field(m => m.EmployeeNumber);
            //Field(m => m.DateCreated);
            //Field<StringGraphType>("DateUpdated", resolve: context => context.Source.DateUpdated.HasValue ? context.Source.DateUpdated.Value.ToShortDateString() : DateTime.MinValue.ToShortDateString());
            //Field(m => m.UserStatus);
            Field(m => m.Username);
            Field<ListGraphType<UserRoleType>, IEnumerable<UserRole>>().Name("UserRoles").ResolveAsync(
                ctx => { return userRoleService.GetUserRolesByUserIdAsync(ctx.Source.Id); });
            Field<ListGraphType<NotificationUserType>, IEnumerable<NotificationUser>>().Name("Notifications").ResolveAsync(
                ctx => { return notificationUserService.GetNotificationUsersByUserIdAsync(ctx.Source.Id); });
            Field<ImageType, ImageDto>().Name("Image")
                .ResolveAsync(ctx => { return imageService.GetImageByIdAsync(ctx.Source.ImageId); });
        }
    }
}
