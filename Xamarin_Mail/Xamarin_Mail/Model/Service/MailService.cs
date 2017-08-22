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
            string _url = Url + "getalllistjson";
            var _result = await _client.GetStringAsync(_url);           
            return JsonConvert.DeserializeObject<List<RecipiantList> > (_result);
            
        }
    }
}
