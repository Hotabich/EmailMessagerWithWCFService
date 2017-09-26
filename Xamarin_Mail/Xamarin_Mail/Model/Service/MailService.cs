using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;
using Xamarin_Mail.Model;


namespace Xamarin_Mail.Model.Service
{
    public class MailService
    {
        const string Url = "http://192.168.0.102:2931/api/sender/";

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<List<RecipiantList>> GetAllList()
        {
            
            HttpClient _client = GetClient();
            string _url = Url + "getalllistForXamarin";
            var _result = await _client.GetStringAsync(_url);           
            return JsonConvert.DeserializeObject<List<RecipiantList>>(_result);
            
        }

        public async Task<List<Recipiant>> GetList(int id)
        {

            HttpClient _client = GetClient();
            string _url = Url + "getRecipiantListForXamarin";
            var response = await _client.PostAsync(_url,
                new StringContent(
                    JsonConvert.SerializeObject(id), Encoding.UTF8, "application/json"));
            if (response.StatusCode != HttpStatusCode.OK)
                return null;

           var result= JsonConvert.DeserializeObject<List<Recipiant>>(
                await response.Content.ReadAsStringAsync());
            return result;
                
        }

        public void DeleteList(int id)
        {
            HttpClient _client = GetClient();
            string _url = Url + "deleteRecipiantList";
            var response = _client.PostAsync(_url,
              new StringContent(
                    JsonConvert.SerializeObject(id),
                    Encoding.UTF8, "application/json"));              
        }

        public void DeleteRecipiant(Recipiant deleteRecipiant)
        {
            HttpClient _client = GetClient();
            string _url = Url + "deleteRecipiantForXamarin";
            var response = _client.PostAsync(_url,
             new StringContent(
                   JsonConvert.SerializeObject(deleteRecipiant),
                   Encoding.UTF8, "application/json"));            
        }

        public async Task<Recipiant[]> AddRecipiant(Recipiant deleteRecipiant)
        {
            HttpClient _client = GetClient();
            string _url = Url + "addRecipiantForXamarin";
            var response = await _client.PostAsync(_url,
             new StringContent(
                   JsonConvert.SerializeObject(deleteRecipiant),
                   Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<Recipiant[]>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<RecipiantList[]> AddList(string nameList)
        {
            HttpClient _client = GetClient();
            string _url = Url + "addListForXamarin";
            var response =  await _client.PostAsync(_url,
             new StringContent(
                   JsonConvert.SerializeObject(nameList),
                   Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<RecipiantList[]>(
                await response.Content.ReadAsStringAsync());
        }

        public async Task<string> Send(Model.Util.Message message)
        {
            HttpClient _client = GetClient();
            string _url = Url + "sendForXamarin";
            var response = await _client.PostAsync(_url,
             new StringContent(
                   JsonConvert.SerializeObject(message),
                   Encoding.UTF8, "application/json"));

            if (response.StatusCode != HttpStatusCode.OK)
                return null;

            return JsonConvert.DeserializeObject<string>(
                await response.Content.ReadAsStringAsync());
        }
    }
}
