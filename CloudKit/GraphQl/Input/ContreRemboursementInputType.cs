using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class ContreRemboursementInputType : InputObjectGraphType
	{
		public ContreRemboursementInputType()
		{
			Name = "ContreRemboursementInputType";
            Field<FloatGraphType>("montant");
            Field<StringGraphType>("ordre");
		}
	}
}
