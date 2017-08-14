using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class ArriveeInputType : InputObjectGraphType
	{
		public ArriveeInputType()
		{
			Name = "ArriveeInputType";
            Field<StringGraphType>("date_livraison");
            Field<StringGraphType>("imperatif_livraison");
            Field<DateGraphType>("date_imperatif_livraison");
			Field<DetailClientInputType>("destinataire");
		}
	}
}
