using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class NotificationType : ObjectGraphType<NotificationDto>
    {
        public NotificationType(INotificationService notifications, IEntityTypeService entityTypes, INotificationUserService notificationUserService)
        {
            Field(m => m.Id);
            Field(m => m.Text);
            Field<EntityTypeType, EntityTypeDto>().Name("EntityType")
                .ResolveAsync(ctx => { return entityTypes.GetEntityTypeIdAsync(ctx.Source.EntityTypeId); });
            Field(m => m.Identifier);
            Field(m => m.DateCreated);
            Field(m => m.IsRead);
            Field<ListGraphType<NotificationUserType>, IEnumerable<NotificationUser>>().Name("Users").ResolveAsync(
                ctx => { return notificationUserService.GetNotificationUsersByNotificationIdAsync(ctx.Source.Id); });
        }
    }
}
