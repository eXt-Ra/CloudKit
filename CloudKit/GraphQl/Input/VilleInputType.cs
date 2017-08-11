using System;
using GraphQL.Types;

namespace CloudKit.GraphQl.Input
{
	public class VilleInputType : InputObjectGraphType
	{
		public VilleInputType()
		{
			Name = "VilleInputType";
			Field<StringGraphType>("vilzcnr");
			Field<StringGraphType>("touzonid");
			Field<StringGraphType>("viltourne");
			Field<StringGraphType>("vilzoned");
			Field<StringGraphType>("vilatlas");
			Field<StringGraphType>("payinter");
			Field<StringGraphType>("vilcp");
			Field<StringGraphType>("villib");
			Field<StringGraphType>("vilid");
			Field<StringGraphType>("dptid");
			Field<StringGraphType>("rgiid");
			Field<StringGraphType>("payid");
			Field<StringGraphType>("dptcode");
			Field<StringGraphType>("dptlib");
		}
	}
}
