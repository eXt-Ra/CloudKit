using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class AriveeType : ObjectGraphType<Arrivee>
    {
		public AriveeType()
		{
            Field(x => x.date_livraison).Description("Date de livraison");
            Field(x => x.imperatif_livraison).Description("Impératif de livraison");
            Field(x => x.date_imperatif_livraison).Description("Date impératif de livraison");
			Field(x => x.telephone).Description("Numéro de téléphone");
			Field<DetailClientType>(
				"destinataire",
				resolve: context =>
				{
                    return context.Source.destinataire;
				}
			);
			//public DetailClient expediteur { get; set; }
		}
    }
}