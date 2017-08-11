using CloudKit.Models;
using GraphQL.Types;

namespace CloudKit.GraphQl.Type
{
    internal class LatLngType : ObjectGraphType<LatLng>
    {
        public LatLngType(){
            Field(x => x.lat).Description("Latitude");
            Field(x => x.lng).Description("Longitude");
            Field(x => x.date).Description("Date");
        }
    }
}