using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class ContreRemboursementType : ObjectGraphType<ContreRemboursement>
    {
        public ContreRemboursementType(){
            Field(x => x.montant).Description("Montant");
			Field(x => x.ordre).Description("Ordre");
        }
    }
}