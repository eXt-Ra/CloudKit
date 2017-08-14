using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class DepartInputType : InputObjectGraphType
	{
		public DepartInputType()
		{
			Name = "DepartInputType";
			Field<StringGraphType>("date_chargement");
			Field<DetailClientInputType>("expediteur");
		}
	}
}
