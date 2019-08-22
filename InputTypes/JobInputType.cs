using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema.InputTypes
{
    using GraphQL.Types;

    public class JobInputType : InputObjectGraphType
    {
        public JobInputType()
        {
            Name = "JobInput";
            Field<IntGraphType>("id");
            Field<IntGraphType>("categoryId");
            Field<IntGraphType>("priorityId");
            Field<StringGraphType>("roleId");
            Field<StringGraphType>("name");
            Field<IntGraphType>("duration");
            Field<BooleanGraphType>("isDeleted");
            Field<IntGraphType>("frequencyId");
            Field<BooleanGraphType>("isActive");
            Field<DateGraphType>("startDate");
            Field<DateGraphType>("endDate");
            Field<IntGraphType>("recurringEvery");
            Field<IntGraphType>("occurrences");
            Field<IntGraphType>("timesHappened");
        }
    }
}
