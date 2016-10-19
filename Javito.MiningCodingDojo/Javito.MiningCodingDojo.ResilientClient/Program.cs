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
            var client = new RestClient("http://localhost:53032/");
            //http://localhost:53032/api/login/LoginMiner?name=Alain
            var request = new RestRequest("api/Login/CreateMiner", Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                Name = "Javi",               
            });

            // execute the request
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            request = new RestRequest("api/Login/LoginMine", Method.PUT);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                Name = "Javi",
            });

            response = client.Execute(request);
            content = response.Content;

            request = new RestRequest("api/Mining/CollectGold", Method.PUT);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(new
            {
                Id = "Javi",
            });

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
