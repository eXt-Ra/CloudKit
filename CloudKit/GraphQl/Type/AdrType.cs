using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class AdrType : ObjectGraphType<Adr>
    {
        public AdrType(){
			Field(x => x.etat).Description("Etat");
			Field(x => x.soumis).Description("Soumis");
        }
    }
}