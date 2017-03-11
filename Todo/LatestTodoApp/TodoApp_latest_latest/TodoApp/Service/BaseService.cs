using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.Service
{
    public class BaseService
    {
        protected HttpClient _client;

        public BaseService(string baseurl)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(baseurl);
        }

        public T getData<T>(string path)
        {
            var result = _client.GetAsync("").Result;
            var data = result.Content.ReadAsAsync<T>().Result;

            return data;
        }
    }
}
