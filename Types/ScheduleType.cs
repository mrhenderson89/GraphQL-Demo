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

    public class ScheduleType : ObjectGraphType<ScheduleDto>
    {
        public ScheduleType(IScheduleService scheduleService, IJobService jobService, IUsersService userService)
        {
            Field(m => m.Id);
            Field<JobType, JobDto>().Name("Job")
                .ResolveAsync(ctx => { return jobService.GetJobByIdAsync(ctx.Source.JobId); });
            Field<UserType, UserDto>().Name("User")
                .ResolveAsync(ctx => { return userService.GetUserByIdAsync(ctx.Source.UserId); });
            Field(m => m.ScheduledDate);
            Field(m => m.DateCompleted, nullable: false, type: typeof(DateGraphType));
            Field(m => m.IsComplete);
        }
    }
}
