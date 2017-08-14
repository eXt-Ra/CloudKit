using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class GpsType : ObjectGraphType<Gps>
    {
		public GpsType()
		{
            Field(x => x.chauffeur).Description("Nom du chauffeur");
            Field<ListGraphType<LatLngType>>(
			   "latlng",
			   resolve: context =>
			   {
				   return context.Source.latlng;
			   }
		   );
			Field<LatLngType>(
			  "lastlatlng",
			  resolve: context =>
			  {
				  return context.Source.lastlatlng;
			  }
		  );
		}
    }
}