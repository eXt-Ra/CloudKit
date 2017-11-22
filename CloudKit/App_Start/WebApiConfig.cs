using System.Net.Http.Headers;
using System.Web.Http;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CloudKit
{
    public static class WebApiConfig
    {
		public static MongoDB.Driver.MongoClient client;
		public static IMongoDatabase database;
		public static IMongoCollection<BsonDocument> collection;
		
        public static void Register(HttpConfiguration config)
        {
            config.EnableCors();

			client = new MongoClient("mongodb://RomainHori:Dealtis25-@localhost:27017/admin");
			database = client.GetDatabase("Horizon");
			collection = database.GetCollection<BsonDocument>("userapis");
			
            // Web API configuration and services
			config.Formatters.JsonFormatter.SupportedMediaTypes
	            .Add(new MediaTypeHeaderValue("text/html"));

            config.Filters.Add(new TokenMiddleware());

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
