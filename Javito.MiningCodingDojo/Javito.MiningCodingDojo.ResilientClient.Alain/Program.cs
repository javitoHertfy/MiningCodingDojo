using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Javito.MiningCodingDojo.ResilientClient.Alain
{
    class Program
    {
        static void Main(string[] args)
        {
            var name = "Grunnon10";

            for (int i = 0; i < 10000000; i++)
            {
                var minero = GetMinieroLogeado(name);
                var count = GetGold(minero);
                SaveGold(minero, count);
            }

            Console.ReadLine();
        }

        static bool CreateMinero(string name) 
        {
            var url = "http://miningcodingdojo.azurewebsites.net";
            var iRestClient = new RestSharp.RestClient(url);

            var request = new RestRequest("/v1/login/CreateMiner/" + name, Method.POST) 
            {
                RequestFormat = DataFormat.Json
            };
            var response = iRestClient.Execute(request);
            var result = response.IsReponseOk();
            if (!result) {
                result = CreateMinero(name);
            }
            return result;
        }

        static bool LoginMiniero(string name)
        {
            var url = "http://miningcodingdojo.azurewebsites.net";
            var iRestClient = new RestSharp.RestClient(url);

            var request = new RestRequest("/v1/login/LoginMine/" + name, Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            var response = iRestClient.Execute(request);
            var result = response.IsReponseOk();
            if (!result)
            {
                result = LoginMiniero(name);
            }
            return result;
        }

        static Mininer GetMiniero(string name)
        {
            var result = default(Mininer);
            var url = "http://miningcodingdojo.azurewebsites.net";
            var iRestClient = new RestSharp.RestClient(url);

            var request = new RestRequest("/v1/login/GetMinerByName/" + name, Method.GET)
            {
                RequestFormat = DataFormat.Json
            };
            var response = iRestClient.Execute(request);
            if(response.IsReponseOk())
            {
                result = JsonConvert.DeserializeObject<Mininer> (response.Content);
            }
            else if (response.StatusCode != System.Net.HttpStatusCode.NotFound)
            {
                result = GetMiniero(name);
            }
            return result;
        }

        class Mininer
        {
            public string Name { get; set; }
            public string Id { get; set; }
            public bool IsLogged { get; set; }
            public int GoldObtained { get; set; }
        }

        static Mininer GetMinieroLogeado(string name)
        {
            var minero = GetMiniero(name);
            if (minero == null)
            {
                Console.WriteLine("CreateMinero");
                CreateMinero(name);
                Console.WriteLine("CreateMinero ok");

                Console.WriteLine("LoginMinero");
                LoginMiniero(name);
                Console.WriteLine("LoginMinero ok");

                minero = GetMiniero(name);
            }
            if (!minero.IsLogged)
            {
                Console.WriteLine("LoginMinero");
                LoginMiniero(name);
                Console.WriteLine("LoginMinero ok");
            }
            return minero;
        }

        static int GetGold(Mininer minero)
        {
            var result = 0;
            var url = "http://miningcodingdojo.azurewebsites.net";
            var iRestClient = new RestSharp.RestClient(url);

            var request = new RestRequest("/v1/Mining/CollectGold/" + minero.Id, Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            var response = iRestClient.Execute(request);
            if (response.IsReponseOk())
            {
                result = Convert.ToInt32(response.Content);
            }
            else 
            {
                Console.WriteLine(response.StatusCode.ToString() + " " +  response.Content);
                var min = GetMinieroLogeado(minero.Name);
                result = GetGold(min);
            }
            return result;
        }

        static bool SaveGold(Mininer minero, int count)
        {
            var url = "http://miningcodingdojo.azurewebsites.net";
            var iRestClient = new RestSharp.RestClient(url);

            var request = new RestRequest("/v1/Mining/SaveGold/" + minero.Id + "/" + count, Method.PUT)
            {
                RequestFormat = DataFormat.Json
            };
            var response = iRestClient.Execute(request);
            var result = response.IsReponseOk();
            if (!result)
            {
                var min = GetMinieroLogeado(minero.Name);
                result = SaveGold(min, min.GoldObtained);
            }
            return result;
        }
    }
}
