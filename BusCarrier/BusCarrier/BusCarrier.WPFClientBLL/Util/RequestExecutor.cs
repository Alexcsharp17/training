using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BusCarrier.WPFClientBLL.Util
{
    public static class RequestExecuter
    {
        public static async Task<HttpResponseMessage> ExecuteRequest(string route, string requestType,
            object data = null)
        {
            var result = requestType switch
            {
                RequestTypes.POST => await ExecutePost(route, data),
                RequestTypes.PUT => await ExecutePut(route, data),
                RequestTypes.DELETE => await ExecuteDelete(route),
                RequestTypes.GET => await ExecuteGet(route),
                _ => await ExecuteGet(route)
            };
            if (result.StatusCode != HttpStatusCode.OK) throw new Exception(await result.Content.ReadAsStringAsync());
            return result;
        }

        private static async Task<HttpResponseMessage> ExecutePost(string route, object data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var dataSerialized = JsonConvert.SerializeObject(data);
                return await client.PostAsync(route,
                    new StringContent(dataSerialized, Encoding.UTF8, "application/json"));
            }
        }

        private static async Task<HttpResponseMessage> ExecutePut(string route, object data)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var dataSerialized = JsonConvert.SerializeObject(data);
                return await client.PutAsync(route,
                    new StringContent(dataSerialized, Encoding.UTF8, "application/json"));
            }
        }

        private static async Task<HttpResponseMessage> ExecuteDelete(string route)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                return await client.DeleteAsync(route);
            }
        }

        private static async Task<HttpResponseMessage> ExecuteGet(string route)
        {
            using (var client = new HttpClient())
            {
                return await client.GetAsync(route);
            }
        }
    }
}
