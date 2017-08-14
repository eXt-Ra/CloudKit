using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class PositionInputType : InputObjectGraphType
	{
		public PositionInputType()
		{
			Name = "PositionInput";
            //NonNullGraphType
            Field<StringGraphType>("numero_chrono");
            Field<NonNullGraphType<StringGraphType>>("reference_interne");
            Field<StringGraphType>("code_client");
            Field<StringGraphType>("code_livreur");
            Field<NonNullGraphType<DepartInputType>>("depart");
            Field<NonNullGraphType<ArriveeInputType>>("arrivee");
            Field<MarchandiseInputType>("marchandise");
            Field<ListGraphType<IntGraphType>>("palettes");
		}
	}
}
