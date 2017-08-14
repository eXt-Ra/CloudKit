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
		}
	}
}
