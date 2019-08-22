using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema.InputTypes
{
    using GraphQL.Types;

    public class NotificationUserInputType : InputObjectGraphType
    {
        public NotificationUserInputType()
        {
            Name = "NotificationUserInputType";
            Field<StringGraphType>("userId");
            Field<StringGraphType>("text");
        }
    }
}
