namespace GraphQLDemo.Schema
{
    using GraphQL;
    using GraphQL.Types;

    using GraphQLDemo.Schema.GraphQLQueries;
    using GraphQLDemo.Schema.Mutations;
    using GraphQLDemo.Schema.Subscriptions;

    public class CheckmateSchema : Schema
    {
        public CheckmateSchema(IDependencyResolver resolver) : base(resolver)
        {
            Query = resolver.Resolve<CheckmateQuery>();
            Mutation = resolver.Resolve<CheckmateMutation>();
            Subscription = resolver.Resolve<CheckmateSubscriptions>();

        }
    }
}