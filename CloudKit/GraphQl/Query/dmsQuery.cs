using System;
using CloudKit.BDD;
using CloudKit.GraphQl.Type;
using GraphQL.Types;

namespace CloudKit.GraphQl.Query
{
    public class dmsQuery : ObjectGraphType
    {
        public static PositionDataAccess positionData = new PositionDataAccess(@"server=DEA_SRV_DMS\SQLEXPRESS;database=ANDSYS_JETTEST;uid=sa;password=jb;");
        public static GpsDataAccess gpsData = new GpsDataAccess(@"server=DEA_SRV_DMS\SQLEXPRESS;database=ANDSYS_JETTEST;uid=sa;password=jb;");
        //public static PositionDataAccess positionData = new PositionDataAccess(@"server=10.1.2.66;database=ANDSYS_JET;uid=sa;password=jb;");
        //public static GpsDataAccess gpsData = new GpsDataAccess(@"server=10.1.2.66;database=ANDSYS_JET;uid=sa;password=jb;");
        public dmsQuery()
        {
            
            Field<PositionType>(
                "position", "Get d'une position <br> ex: {\n  position(positionNumber: \"1708022043\") {\n    numero_chrono\n    evenement{\n      date\n      information\n    }\n  }\n}",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "positionNumber", Description = "Numéro de position" },
                    new QueryArgument<StringGraphType> { Name = "parcelNumber", Description = "Numéro de colis" }
                ),
                resolve: (context) =>
                {
                    if (context.GetArgument<string>("positionNumber") != null)
                    {
                        return positionData.GetPositionWithPositionNumber(context.GetArgument<string>("positionNumber"));
                    }
                    else if (context.GetArgument<string>("parcelNumber") != null)
                    {
                        return positionData.GetPositionWithParcelNumber(context.GetArgument<string>("parcelNumber"));
                    }
                    return null;
                }
            );
            Field<ListGraphType<PositionType>>(
                "positions", "Get d'une liste de positions",
                arguments: new QueryArguments(
                    new QueryArgument<StringGraphType> { Name = "codeChauffeur", Description = "Nom du chauffeur" },
                    new QueryArgument<StringGraphType> { Name = "dateFrom", Description = "de" },
                    new QueryArgument<StringGraphType> { Name = "dateTo", Description = "à" },
                    new QueryArgument<StringGraphType> { Name = "groupageNumber", Description = "Numéro de groupage" }
                ),
                resolve: (context) =>
                {
                    if (context.GetArgument<string>("codeChauffeur") != null)
                    {
                        return positionData.GetPositionWithCodeChauffeur(context.GetArgument<string>("codeChauffeur"), context.GetArgument<string>("dateFrom") == null ? DateTime.Now.ToString("d") : context.GetArgument<string>("dateFrom"), context.GetArgument<string>("dateTo") == null ? DateTime.Now.ToString("d") : context.GetArgument<string>("dateTo"));
                    }
                    else if (context.GetArgument<string>("groupageNumber") != null)
                    {
                        return positionData.GetPositionWithGroupageNumber(context.GetArgument<string>("groupageNumber"));
                    }
                    return null;
                }
            );
			Field<GpsType>(
			  "gps", "Get location",
				arguments: new QueryArguments(
					new QueryArgument<StringGraphType> { Name = "codeChauffeur", Description = "Nom du chauffeur" },
					new QueryArgument<StringGraphType> { Name = "dateFrom", Description = "de" },
					new QueryArgument<StringGraphType> { Name = "dateTo", Description = "à" }
				),
				resolve: (context) =>
				{
					if (context.GetArgument<string>("codeChauffeur") != null)
					{
						return gpsData.GetGpsWithCodeChauffeur(context.GetArgument<string>("codeChauffeur"), context.GetArgument<string>("dateFrom") == null ? DateTime.Now.ToString("d") : context.GetArgument<string>("dateFrom"), context.GetArgument<string>("dateTo") == null ? DateTime.Now.ToString("d") : context.GetArgument<string>("dateTo"));
					}
					return null;
				}
			);
        }
    }
}
