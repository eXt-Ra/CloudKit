using GraphQL.Types;
using CloudKit.Models;
namespace CloudKit.GraphQl.Type
{
    internal class VilleType : ObjectGraphType<Ville>
    {
        public VilleType(){
			Field(x => x.vilzcnr).Description("???");
			Field(x => x.touzonid).Description("???");
			Field(x => x.viltourne).Description("???");
			Field(x => x.vilzoned).Description("???");
			Field(x => x.vilatlas).Description("???");
			Field(x => x.payinter).Description("???");
			Field(x => x.vilcp).Description("???");
			Field(x => x.villib).Description("???");
			Field(x => x.vilid).Description("???");
			Field(x => x.dptid).Description("???");
			Field(x => x.rgiid).Description("???");
			Field(x => x.payid).Description("???");
			Field(x => x.dptcode).Description("???");
			Field(x => x.dptlib).Description("???");			
        }
    }
}