using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class DetailClientInputType : InputObjectGraphType
	{
		public DetailClientInputType()
		{
			Name = "DetailClientInputType";
			Field<NonNullGraphType<StringGraphType>>("raison_sociale");
			Field<NonNullGraphType<StringGraphType>>("adresse");
			Field<NonNullGraphType<StringGraphType>>("code_postal");
			Field<NonNullGraphType<StringGraphType>>("ville");
			Field<NonNullGraphType<StringGraphType>>("pays");
			Field<StringGraphType>("clientId");
			Field<StringGraphType>("clientCode");
			Field<StringGraphType>("adresse2");
			Field<VilleInputType>("detail");
		}
	}
}
