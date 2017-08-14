using System;
using GraphQL.Types;
using CloudKit.Models;

namespace CloudKit.GraphQl.Type
{
    public class PositionType : ObjectGraphType<Result>
    {
        public PositionType()
        {
            Field(x => x.numero_chrono).Description("Numéro de position");
            Field(x => x.reference_interne).Description("Référence du client");
            Field(x => x.code_client).Description("Numéro de siret du client pour transmission EDI");
            Field(x => x.code_livreur).Description("Numéro de siret du livreur pour transmission EDI");

            Field<DepartType>(
                "depart",
                resolve: context =>
                {
                    return context.Source.depart;
                }
            );
            Field<AriveeType>(
                "arrivee",
                resolve: context =>
                {
                    return context.Source.arrivee;
                }
            );
            Field<MarchandiseType>(
                "marchandise",
                resolve: context =>
                {
                    return context.Source.marchandise;
                }
            );
            //Field(x => x.palettes).Description("Codebarres des étiquettes de UM");
        }
    }
}
