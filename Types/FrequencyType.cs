using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLDemo.Schema
{
    using GraphQL.Types;

    using GraphQLDemo.Models;
    using GraphQLDemo.Services.Interfaces;

    public class FrequencyType : ObjectGraphType<FrequencyDto>
    {
        public FrequencyType(IFrequencyService frequencyService)
        {
            Field(m => m.Id).Name("Id").Description("FrequencyId");
            Field(m => m.Name).Name("Name").Description("Frequency Name");
            Field(m => m.Selected).Name("Selected").Description("Frequency Selected");
            Field(m => m.NumberOfRecords).Name("NumberOfRecords").Description("Number of Frequency Records");
        }
    }
}
