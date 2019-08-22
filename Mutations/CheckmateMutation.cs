using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema.Mutations
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Schema.InputTypes;
    using GraphQLDemo.Schema.WebSockets;
    using GraphQLDemo.Services.Interfaces;
    using GraphQLDemo.WebSocketManager;

    using Newtonsoft.Json.Linq;

    public class CheckmateMutation : ObjectGraphType
    {
        public CheckmateMutation(ITaskResultService taskResultService, INotificationUserService notificationUserService, IJobService jobService, IWebSocketWriter webSocketWriter)
        {
            Field<TaskResultType>(
                Name = "CreateTaskResult",
                Description = "Create a new TaskResult",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TaskResultInputType>> { Name = "taskResult" }
                        ),
                resolve: context =>
                    {
                        var taskResult = context.GetArgument<TaskResultDto>("taskResult");
                        return taskResultService.AddTaskResult(taskResult);
                    });

            Field<TaskResultType>(
                Name = "UpdateTaskResult",
                Description = "Update a TaskResult",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<TaskResultInputType>> { Name = "taskResult" }
                ),
                resolve: context =>
                    {
                        var taskResult = context.GetArgument<TaskResultDto>("taskResult");
                        return taskResultService.UpdateTaskResult(taskResult);
                    });

            Field<NotificationUserType>(
                Name = "CreateUserNotification",
                Description = "Create a new UserNotification, given the text of the Notification, and the user who will receive the Notification",
                arguments: new QueryArguments {
                                                      new QueryArgument<StringGraphType> {
                                                                                                  Name = "userId"
                                                                                              },
                                                      new QueryArgument<StringGraphType> {
                                                                                                 Name = "text"
                                                                                             }
                                                  },
                resolve: context =>
                    {
                        var userId = context.GetArgument<String>("userId");
                        var notificationText = context.GetArgument<String>("text");
                        var userNotificationResult = notificationUserService.AddNotificationUser(userId.ToString(), notificationText.ToString());
                        webSocketWriter.SendToGroup(userId, new GQLMessage
                                                                                              {
                                                                                                  Type = GQLMessageTypes.GQL_DATA,
                            //wrap message in a data element to match what subscription-transport-ws.SubscriptionClient is expecting
                            Payload = JObject.FromObject(new { data = userNotificationResult.Result.Notification })
                            //Payload = JObject.FromObject(new { data = notificationText })
                        }).Wait();
                        return userNotificationResult;
                    });

            Field<JobType>(
                Name = "CreateJob",
                Description = "Create a new Job",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<JobInputType>> { Name = "job" }
                ),
                resolve: context =>
                    {
                        var job = context.GetArgument<JobDto>("job");
                        return jobService.AddJob(job);
                    });

        }
    }
}
