using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class DepartInputType : InputObjectGraphType
	{
		public DepartInputType()
		{
			Name = "DepartInputType";
			Field<NonNullGraphType<StringGraphType>>("date_chargement");
			Field<NonNullGraphType<DetailClientInputType>>("expediteur");
            Field<StringGraphType>("reference_chargement");
            Field<StringGraphType>("telephone");
        }
	}
}
