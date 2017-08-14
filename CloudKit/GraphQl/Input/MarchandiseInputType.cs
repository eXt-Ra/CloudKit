using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class MarchandiseInputType : InputObjectGraphType
	{
		public MarchandiseInputType()
		{
			Name = "MarchandiseInputType";
            Field<IntGraphType>("nombre_colis");
            Field<IntGraphType>("nombre_etiquettes");
            Field<FloatGraphType>("metre_lineaire");
            Field<FloatGraphType>("poids");
            Field<IntGraphType>("palettes_euro");
            Field<BooleanGraphType>("porteur");
            Field<BooleanGraphType>("hayon_tp");
            Field<BooleanGraphType>("pal_demie");
            Field<BooleanGraphType>("restitution_euro");
            Field<AdrInputType>("adr");
            Field<StringGraphType>("type");
            Field<ContreRemboursementInputType>("contre_remboursement");
            Field<StringGraphType>("observations");
            Field<ListGraphType<StringGraphType>>("palettes");



		}
	}
}
