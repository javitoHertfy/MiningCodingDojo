using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace Javito.MiningCodingDojo.ResilientClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient("http://miningcodingdojo.azurewebsites.net/");
            //http://localhost:53032/v1/login/CreateMiner/{0}
            var request = new RestRequest("/v1/login/CreateMiner/{name}", Method.POST);
            request.AddParameter("name", "Javito Hertfy");

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            request = new RestRequest("/v1/login/LoginMine/{name}", Method.PUT);
            request.AddParameter("name", "Javito Hertfy");

            response = client.Execute(request);
            content = response.Content;

            request = new RestRequest("/v1/login/GetMinerByName/{name}", Method.GET);
            response = client.Execute(request);
            content = response.Content;

            request = new RestRequest("api/Mining/SaveGold", Method.PUT);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                Id = "Javi",
                goldQuantity = 1
            });

            response = client.Execute(request);
            content = response.Content;


        }
    }
}
