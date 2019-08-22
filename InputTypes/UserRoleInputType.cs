namespace GraphQLDemo.Schema.InputTypes
{
    using GraphQL.Types;

    public class UserRoleInputType : InputObjectGraphType
    {
        public UserRoleInputType()
        {
            Name = "UserRoleInput";
            Field<NonNullGraphType<StringGraphType>>("userId");
            Field<NonNullGraphType<StringGraphType>>("roleId");
        }
    }
}
