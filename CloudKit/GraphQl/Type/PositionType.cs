using System;
using GraphQL.Types;
using CloudKit.Models;
using CloudKit.BDD;

namespace CloudKit.GraphQl.Type
{
    public class PositionType : ObjectGraphType<Result>
    {
        public static EvenementDataAccess gpsData = new EvenementDataAccess(@"server=10.1.2.66;database=ANDSYS_JET;uid=sa;password=jb;");
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
            Field<ListGraphType<EvenementType>>(
                "evenement",
                resolve: context =>
                {
                    return gpsData.GetEventFromPosition(context.Source.id);
                }
            );

            //Field(x => x.palettes).Description("Codebarres des étiquettes de UM");
        }
    }
}
