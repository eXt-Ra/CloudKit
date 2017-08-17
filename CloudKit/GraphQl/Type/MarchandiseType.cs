using System;
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
            Field<StringGraphType>(
                "poids",
                 arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "unite", Description = "Unité du poids" }
                ),
                resolve: context =>
                {
                    if (context.GetArgument<string>("unite") != null)
                    {
                        switch (context.GetArgument<string>("unite"))
                        {
                            case "kg":
                                return context.Source.poids * 1000;
                            case "tonne":
                                return context.Source.poids;
                            default:
                                return ("Argument unité non valide, kg ou tonne");
                        }
                    }
                    else
                    {
                        return context.Source.poids;
                    }
                });
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