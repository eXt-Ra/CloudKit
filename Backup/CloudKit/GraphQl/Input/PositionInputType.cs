using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class PositionInputType : InputObjectGraphType
	{
		public PositionInputType()
		{
			Name = "PositionInput";
			Field<StringGraphType>("numero_chrono");
			Field<StringGraphType>("reference_interne");
			Field<DepartInputType>("depart");
		}
	}
}
