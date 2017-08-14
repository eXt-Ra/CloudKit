using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class PaletteInputType : InputObjectGraphType
	{
		public PaletteInputType()
		{
			Name = "PaletteInputType";
            Field<IntGraphType>("facturees");
            Field<IntGraphType>("coup_de_fourches");
            Field<IntGraphType>("totales");
		}
	}
}
