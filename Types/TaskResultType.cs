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

    public class TaskResultType : ObjectGraphType<TaskResultDto>
    {
        public TaskResultType(ITaskResultService taskResultService, ITaskService taskService, IScheduleService scheduleService, IImageService imageService)
        {
            Field(m => m.Id);
            Field<TaskType, TaskDto>().Name("Task")
                .ResolveAsync(ctx => { return taskService.GetTaskByIdAsync(ctx.Source.TaskId); });
            Field<ScheduleType, ScheduleDto>().Name("Schedule")
                .ResolveAsync(ctx => { return scheduleService.GetScheduleByIdAsync(ctx.Source.ScheduleId); });
            Field(m => m.Checked);
            Field(m => m.Note);
            Field<ImageType, ImageDto>().Name("Image")
                .ResolveAsync(ctx => { return imageService.GetImageByIdAsync(ctx.Source.ImageId); });
            Field(m => m.DateTimeCompleted, nullable: false, type: typeof(DateGraphType));
        }
    }
}
