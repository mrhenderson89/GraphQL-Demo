namespace GraphQLDemo.Schema.Subscriptions
{
    using System;
    using System.Linq;
    using System.Security.Claims;

    using GraphQL;
    using GraphQL.Resolvers;
    using GraphQL.Server.Transports.Subscriptions.Abstractions;
    using GraphQL.Server.Transports.WebSockets;
    using GraphQL.Subscription;
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;
    using GraphQLDemo.WebSocketManager;

    using Newtonsoft.Json.Linq;

    public class CheckmateSubscriptions : ObjectGraphType<object>
    {
        public readonly INotificationService notificationService;

        public CheckmateSubscriptions(WebSocketConnectionManager connectionManager, INotificationService notificationService)
        {
            notificationService = this.notificationService;
            Name = "notificationSubscription";
            AddField(new EventStreamFieldType
                         {
                             Name = "userNotifications",
                             Description = "Subscribe to notifications for a particular User",
                             Type = typeof(NotificationUserType),
                             Arguments = new QueryArguments {
                                                                    new QueryArgument<StringGraphType>{Name = "userId"}
                                                                },
                             Resolver = new FuncFieldResolver<NotificationUser>(x =>
                                 {
                                     var notification = x.Source as NotificationUser;
                                     return notification;
                                 }),
                             Subscriber = new EventStreamResolver<NotificationUser>(x =>
                                 {
                                     var user = x.GetArgument<String>("userId");
                                     var context = JObject.FromObject(x.UserContext);
                                     string socketId = context.SelectToken("$..socketId").ToString();
                                     string opId = context.SelectToken("$..opId").ToString();
                                     connectionManager.AddToGroup(socketId, opId, user);
                                     return null;
                                 })
                         });
        }
    }
}
