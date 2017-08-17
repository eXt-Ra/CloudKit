using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class EvenementType : ObjectGraphType<Evenement>
    {
        public EvenementType()
        {
            Field(x => x.code).Description("Code de l'évènement");
            Field(x => x.libelle).Description("Libelle de l'évènement");
            Field(x => x.date).Description("Date de l'évènement");
            Field(x => x.remarque).Description("Remarque de l'évènement");
			Field(x => x.information).Description("Information l'évènement");
        }
    }
}
