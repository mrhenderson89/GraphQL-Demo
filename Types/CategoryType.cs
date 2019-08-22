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

    public class CategoryType : ObjectGraphType<CategoryDto>
    {
        public CategoryType(ICategoryService categoryService)
        {
            Field(m => m.Id).Name("Id").Description("CategoryId");
            Field(m => m.Name).Name("Name").Description("Category Name");
            Field(m => m.Description).Name("Description").Description("Category Description");
            Field(m => m.SortOrder).Name("SortOrder").Description("Category Sort Order");
            Field(m => m.IsDeleted).Name("IsDeleted").Description("Category Is Deleted");
        }
    }
}
