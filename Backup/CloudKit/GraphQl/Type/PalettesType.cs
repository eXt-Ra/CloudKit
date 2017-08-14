using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class PalettesType : ObjectGraphType<Palettes>
    {
        public PalettesType(){
            Field(x => x.facturees).Description("Facturees");
            Field(x => x.coup_de_fourches).Description("Nombre de coup de fourches");
			Field(x => x.totales).Description("Totales");
        }
    }
}