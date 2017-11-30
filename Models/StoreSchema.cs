using System;
using GraphQL.Types;

namespace aspnetcoregraphql.Models
{
    public class StoreSchema : Schema
    {
        public StoreSchema(Func<Type, GraphType> resolveType) : base(resolveType)
        {
            Query = (StoreQuery)resolveType(typeof(StoreQuery));
        }
    }
}

