using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Http;
using GraphQL;
using GraphQL.Types;
using CloudKit.Models;
using CloudKit.GraphQl.Type;
using CloudKit.BDD;
using System.Net.Http;
using System.Net;
using GraphQL.Net;
using System.Web.Http.Cors;
using CloudKit.GraphQl.Query;
using CloudKit.GraphQl.Input;
using RestSharp;
using Newtonsoft.Json;

namespace CloudKit.Controllers
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }
        public object Variables { get; set; }
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class GraphQlController : ApiController
    {
        public async Task<HttpResponseMessage> Post([FromBody]GraphQLQuery query)
        {
            var schema = new Schema { Query = new dmsQuery(), Mutation = new dmsMutation() };

            var queryToExecute = query.Query;
            var inputs = query.Variables.ToString().ToInputs();

            var result = await new DocumentExecuter().ExecuteAsync(_ =>
            {
                _.Schema = schema;
                _.Query = queryToExecute;
                _.Inputs = inputs;
            }).ConfigureAwait(false);

            if (result != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Aucun résultat");
            }
        }

        internal class dmsMutation : ObjectGraphType<object>
        {
            public dmsMutation()
            {
                Field<PositionType>(
                "updatePos",
                arguments: new QueryArguments(
                    //new QueryArgument<NonNullGraphType<StringGraphType>> { Name = "positionNumber", Description = "" },
                    new QueryArgument<NonNullGraphType<PositionInputType>> { Name = "position" }
                ),
                resolve: context =>
                {
                    var updatepos = context.GetArgument<Result>("position");
                    List<string> fields = new List<string>();
                    List<string> values = new List<string>();

                    if (updatepos.numero_chrono != null)
                    {
                        fields.Add("numero_chrono");
                        values.Add(updatepos.numero_chrono);
                    }
                    if (updatepos.reference_interne != null)
                    {
                        fields.Add("reference_interne");
                        values.Add(updatepos.reference_interne);
                    }
                    return updatepos;
                });


                Field<PositionType>(
                "createOrder",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<PositionInputType>> { Name = "order" }
                ),
                resolve: context =>
                {
                    var order = context.GetArgument<Result>("order");
                    var client = new RestClient("http://localhost/dataws/api/importorder");
                    var request = new RestRequest(Method.POST);
                    request.AddHeader("content-type", "application/json");
                    request.AddParameter("application/json", JsonConvert.SerializeObject(order), ParameterType.RequestBody);
                    IRestResponse response = client.Execute(request);
                    return order;
                });

            }
        }
    }
}
