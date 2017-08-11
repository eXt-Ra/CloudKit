using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class MarchandiseType : ObjectGraphType<Marchandise>
    {
        public MarchandiseType()
        {
            Field(x => x.nombre_colis).Description("Nombre de colis");
            Field(x => x.nombre_etiquettes).Description("Nombre d'étiquette");
            Field(x => x.volume).Description("Volume");
            Field(x => x.metre_lineaire).Description("Mètre linéaire");
            Field(x => x.poids).Description("Poids");
            Field(x => x.palettes_euro).Description("Palettes europe");
            Field(x => x.porteur).Description("Porteur");
            Field(x => x.hayon_tp).Description("Hayon");
            Field(x => x.restitution_euro).Description("Restitution euro");
            Field(x => x.type).Description("TYPE");
            Field(x => x.observations).Description("Observations");
            Field<PalettesType>(
                "palettes",
                resolve: context =>
                {
                    return context.Source.palettes;
                }
            );
            Field<AdrType>(
                "adr",
                resolve: context =>
                {
                    return context.Source.adr;
                }
            );
            Field<ContreRemboursementType>(
                "contre_remboursement",
                resolve: context =>
                {
                    return context.Source.contre_remboursement;
                }
            );
        }
    }
}