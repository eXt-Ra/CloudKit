using GraphQL.Types;
using CloudKit.Models;
namespace CloudKit.GraphQl.Type
{
    public class DetailClientType : ObjectGraphType<DetailClient>
    {
        public DetailClientType()
        {
            Field(x => x.raison_sociale).Description("Nom de la société");
            Field(x => x.adresse).Description("Adresse");
            Field(x => x.code_postal).Description("Code postal");
            Field(x => x.ville).Description("Ville");
            Field(x => x.pays).Description("Pays");
            //Field<VilleType>(
			//	"detail",
			//	resolve: context =>
			//	{
			//		return context.Source.detail;
			//	}
			//);
            Field(x => x.clientId).Description("Id du client");
            Field(x => x.clientCode).Description("Code du client");
            Field(x => x.adresse2).Description("Seconde ligne d'adresse");
    }
}
}