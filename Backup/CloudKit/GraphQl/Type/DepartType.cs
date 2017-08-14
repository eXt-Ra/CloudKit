using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class DepartType : ObjectGraphType<Depart>
    {
        public DepartType(){
            Field(x => x.date_chargement).Description("Date du chargement");
            Field<DetailClientType>(
				"expediteur",
				resolve: context =>
				{
                    return context.Source.expediteur;
				}
			);
        }
            
    }
}