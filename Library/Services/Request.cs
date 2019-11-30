using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    public class Request : IRequest
    {
       

        public Task<Tresult> GetAsync<Tresult>(string uri)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.GetAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();

            Tresult result = await Task.Run(() => JsonConvert.DeserializeObject<Tresult>(serialized));

            return result;

        }

        public Task<int> PostAsync<Tresult>(string uri, Tresult data)
        {
            throw new NotImplementedException();
        }

        public Task<int> PutAsync<Tresult>(string uri, Tresult data)
        {
            throw new NotImplementedException();
        }
        public Task<int> DeleteAsync<Tresult>(string uri)
        {
            HttpClient httpClient = new HttpClient();
            HttpResponseMessage response = await httpClient.DeleteAsync(uri);
            string serialized = await response.Content.ReadAsStringAsync();
            return Convert.ToInt32(serialized);

        }
    }
}
