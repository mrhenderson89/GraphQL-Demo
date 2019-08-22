namespace GraphQLDemo.Schema.GraphQLQueries
{
    using System.Collections.Generic;

    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class CheckmateQuery : ObjectGraphType
    {
        public CheckmateQuery(IUsersService users, IRoleService roles, IUserRoleService userRoles, IImageService images, IJobService jobs,
                              INotificationService notifications, IPriorityService priorities,
                              INotificationUserService notificationUsers, IScheduleService schedules, ITaskService tasks, ITaskResultService taskResults, IConfirmationService confirmations,
        IEntityTypeService entityTypes,
                           ICategoryService categories,
        IFrequencyService frequencies)
        {
            Field<ListGraphType<UserType>>(
                Name = "Users",
                Description = "Get the list of Users",
                resolve: context => users.GetUsersAsync());

            Field<UserType>(
                Name = "User",
                Description = "Get a particular User with a given UserId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id", Description = "Id of the user"
                        }),
                resolve: context => users.GetUserByIdAsync(context.GetArgument<string>("id")));

            Field<ListGraphType<RoleType>>("Roles", resolve: context => roles.GetRolesAsync());

            Field<RoleType>(
                Name = "Role",
                Description = "Get a particular Role with a given RoleId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the role"
                        }),
                resolve: context => roles.GetRoleById(context.GetArgument<string>("id")));

            Field<ListGraphType<UserRoleType>, IEnumerable<UserRole>>().Name("UserRoles").Description("Get the list of UserRoles")
                .ResolveAsync(ctx => userRoles.GetUserRolesAsync());

            Field<ListGraphType<ImageType>>(
                Name = "Images",
                Description = "Get the list of Images",
                resolve: context => images.GetImagesAsync());

            Field<ImageType>(
                Name = "Image",
                Description = "Get a particular Image with a given ImageId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the image"
                        }),
                resolve: context => images.GetImageByIdAsync(context.GetArgument<int>("id")));

            Field<ListGraphType<JobType>>(
                Name = "Jobs",
                Description = "Get the list of Jobs",
                resolve: context => jobs.GetJobsAsync());

            Field<JobType>(
                Name = "Job",
                Description = "Get a particular Job with a given JobId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the job"
                        }),
                resolve: context => jobs.GetJobByIdAsync(context.GetArgument<long>("id")));

            Field<ListGraphType<NotificationType>>(
                Name = "Notifications",
                Description = "Get the list of Notifications",
                resolve: context => notifications.GetNotificationsAsync());

            Field<NotificationType>(
                Name = "Notification",
                Description = "Get a particular Notification with a given NotificationId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the notification"
                        }),
                resolve: context => notifications.GetNotificationByIdAsync(context.GetArgument<long>("id")));

            Field<ListGraphType<PriorityType>>(
                Name = "Priorities",
                Description = "Gets the list of Priorities",
                resolve: context => priorities.GetPrioritiesAsync());

            Field<PriorityType>(
                Name = "Priority",
                Description = "Get a particular Priority with a given PriorityId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the priority"
                        }),
                resolve: context => priorities.GetPriorityByIdAsync(context.GetArgument<short>("id")));

            Field<ListGraphType<NotificationUserType>, IEnumerable<NotificationUser>>().Name("NotificationUsers")
                .ResolveAsync(ctx => notificationUsers.GetNotificationUsersAsync());

            Field<ListGraphType<ScheduleType>>(
                Name = "Schedules",
                Description = "Gets the list of Schedules",
                resolve: context => schedules.GetSchedulesAsync());

            Field<ConfirmationType>(
                Name = "Schedule",
                Description = "Get a particular Schedule with a given ScheduleId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the schedule"
                        }),
                resolve: context => schedules.GetScheduleByIdAsync(context.GetArgument<long>("id")));

            Field<ListGraphType<TaskResultType>>(
                Name = "TaskResults",
                Description = "Gets the list of TaskResults",
                resolve: context => taskResults.GetTaskResultsAsync());

            Field<TaskResultType>(
                Name = "TaskResult",
                Description = "Get a particular TaskResult with a given TaskResultId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the task"
                        }),
                resolve: context => taskResults.GetTaskResultByIdAsync(context.GetArgument<long>("id")));

            Field<ListGraphType<TaskType>>(
                Name = "Tasks",
                Description = "Gets the list of Tasks",
                resolve: context => tasks.GetTasksAsync());

            Field<TaskType>(
                Name = "Task",
                Description = "Get a particular Task with a given TaskId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                        {
                            Name = "id",
                            Description = "Id of the task"
                        }),
                resolve: context => tasks.GetTaskByIdAsync(context.GetArgument<long>("id")));


            Field<ListGraphType<FrequencyType>>(
                Name = "Frequencies",
                Description = "Gets the list of Frequencies",
                resolve: context => frequencies.GetFrequenciesAsync());

            Field<FrequencyType>(
                Name = "Frequency",
                Description = "Get a particular Frequency with a given FrequencyId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id",
                        Description = "Id of the frequency"
                    }),
                resolve: context => frequencies.GetFrequencyIdAsync(context.GetArgument<int>("id")));

            Field<ListGraphType<EntityTypeType>>(
                Name = "EntityTypes",
                Description = "Gets the list of EntityTypes",
                resolve: context => entityTypes.GetEntityTypesAsync());

            Field<EntityTypeType>(
                Name = "EntityType",
                Description = "Get a particular EntityType with a given EntityTypeId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id",
                        Description = "Id of the entity type"
                    }),
                resolve: context => entityTypes.GetEntityTypeIdAsync(context.GetArgument<int>("id")));

            Field<ListGraphType<CategoryType>>(
                Name = "Categories",
                Description = "Gets the list of Categories",
                resolve: context => categories.GetCategoriesAsync());

            Field<CategoryType>(
                Name = "Category",
                Description = "Get a particular Category with a given CategoryId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id",
                        Description = "Id of the category"
                    }),
                resolve: context => categories.GetCategoryIdAsync(context.GetArgument<int>("id")));

            Field<ListGraphType<ConfirmationType>>(
                Name = "Confirmations",
                Description = "Gets the list of Confirmations",
                resolve: context => confirmations.GetConfirmationsAsync());

            Field<ConfirmationType>(
                Name = "Confirmation",
                Description = "Get a particular Confirmation with a given ConfirmationId",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<StringGraphType>>
                    {
                        Name = "id",
                        Description = "Id of the confirmation"
                    }),
                resolve: context => confirmations.GetConfirmationByIdAsync(context.GetArgument<short>("id")));

        }
    }
}
