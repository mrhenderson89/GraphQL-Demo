using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema.InputTypes
{
    using GraphQL.Types;

    public class TaskResultInputType : InputObjectGraphType
    {
        public TaskResultInputType()
        {
            Name = "TaskResultInput";
            Field<IntGraphType>("id");
            Field<NonNullGraphType<IntGraphType>>("taskId");
            Field<NonNullGraphType<IntGraphType>>("scheduleId");
            Field<NonNullGraphType<BooleanGraphType>>("checked");
            Field<StringGraphType>("note");
            Field<NonNullGraphType<IntGraphType>>("imageId");
        }
    }
}
