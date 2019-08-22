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

    public class TaskType : ObjectGraphType<TaskDto>
    {
        public TaskType(ITaskService taskService, IJobService jobService, IConfirmationService confirmationService)
        {
            Field(m => m.Id);
            Field<JobType, JobDto>().Name("Job")
                .ResolveAsync(ctx => { return jobService.GetJobByIdAsync(ctx.Source.JobId); });
            Field<ConfirmationType, ConfirmationDto>().Name("Confirmation")
                .ResolveAsync(ctx => { return confirmationService.GetConfirmationByIdAsync(ctx.Source.ConfirmationId); });
            Field(m => m.Description);
            Field(m => m.HelpText);
            Field(m => m.IsDeleted);
            Field(m => m.SortOrder);
            Field(m => m.IsComplete);
            Field(m => m.CompletedBy);
            Field(m => m.CompletedDate, nullable: false, type: typeof(DateGraphType));
        }
    }
}
