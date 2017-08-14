using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class DetailClientInputType : InputObjectGraphType
	{
		public DetailClientInputType()
		{
			Name = "DetailClientInputType";
			Field<StringGraphType>("raison_sociale");
			Field<StringGraphType>("adresse");
			Field<StringGraphType>("code_postal");
			Field<StringGraphType>("ville");
			Field<StringGraphType>("pays");
			Field<StringGraphType>("clientId");
			Field<StringGraphType>("clientCode");
			Field<StringGraphType>("adresse2");
			Field<VilleInputType>("detail");
		}
	}
}
