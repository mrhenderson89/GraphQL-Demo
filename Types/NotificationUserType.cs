using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class NotificationUserType : ObjectGraphType<NotificationUser>
    {
        public NotificationUserType(IUsersService userService, INotificationService notificationService)
        {
            Field(i => i.UserId);

            Field<UserType, UserDto>().Name("User").ResolveAsync(ctx => userService.GetUserByIdAsync(ctx.Source.UserId));

            Field(i => i.NotificationId);

            Field<NotificationType, NotificationDto>().Name("Notification").ResolveAsync(ctx => notificationService.GetNotificationByIdAsync(ctx.Source.NotificationId));

        }
    }
}
