using System;
using MongoDB.Bson;
using MongoDB.Driver;
namespace CloudKit
{
    internal class UserAuthorizations
    {
		public bool ValidateToken(string authorizedToken, string userAgent)
		{
			bool result = false;
			try
			{
                BsonDocument document = WebApiConfig.collection.Find(Builders<BsonDocument>.Filter.Eq("token", authorizedToken)).First();
                if (document != null && document.GetElement("active").Value.AsBoolean){
                    return true;
                }
            }
			catch (Exception e)
			{
				e.ToString();
			}
			return result;
		}
    }
}