using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class AdrInputType : InputObjectGraphType
	{
		public AdrInputType()
		{
			Name = "AdrInputType";
            Field<BooleanGraphType>("etat");
            Field<BooleanGraphType>("soumis");
		}
	}
}
