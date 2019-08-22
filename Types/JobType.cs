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

    public class JobType : ObjectGraphType<JobDto>
    {
        public JobType(IJobService jobService, ICategoryService categoryService, IPriorityService priorityService, IRoleService roleService, IFrequencyService frequencyService)
        {
            Field(m => m.Id);
            Field<CategoryType, CategoryDto>().Name("Category")
                .ResolveAsync(ctx => { return categoryService.GetCategoryIdAsync(ctx.Source.CategoryId); });
            Field<PriorityType, PriorityDto>().Name("Image")
                .ResolveAsync(ctx => { return priorityService.GetPriorityByIdAsync(ctx.Source.PriorityId); });
            Field<RoleType, RoleDto>().Name("Role")
                .ResolveAsync(ctx => { return roleService.GetRoleByIdAsync(ctx.Source.RoleId); });
            Field(m => m.Name);
            Field(m => m.Duration);
            Field(m => m.IsDeleted);
            Field<FrequencyType, FrequencyDto>().Name("Frequency")
                .ResolveAsync(ctx => { return frequencyService.GetFrequencyIdAsync(ctx.Source.FrequencyId); });
            Field(m => m.IsActive);
            Field(m => m.StartDate);
            Field(m => m.EndDate);
            Field(m => m.RecurringEvery);
            Field(m => m.Occurrences);
            Field(m => m.TimesHappened);
        }
    }
}
