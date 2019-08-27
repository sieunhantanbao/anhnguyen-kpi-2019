using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SD2411.KPI2019.Infrastructure.HttpHelpers
{
    public class RestInvoker
    {
        private IHttpContextAccessor _contextAccessor;
        private readonly HttpClient _client;
        private const string Authorization = "Authorization";

        public RestInvoker(HttpClient client, IHttpContextAccessor contextAccessor) : base()
        {
            _client = client;
            _contextAccessor = contextAccessor;
        }

        private Uri GetUri(string serviceUri)
        {
            return new Uri(serviceUri);
        }

        /// <summary>
        /// add headers to current Http client, if header header is existed will be removed
        /// </summary>
        /// <param name="headers"></param>
        private void AddHeader(Dictionary<string, string> headers)
        {
            // Add Authorization to header
            _contextAccessor.HttpContext.Request.Headers.TryGetValue(Authorization, out var bearer_token);

            if (_client.DefaultRequestHeaders.Contains(Authorization))
                _client.DefaultRequestHeaders.Remove(Authorization);

            if (!string.IsNullOrEmpty(bearer_token))
                _client.DefaultRequestHeaders.Add(Authorization, bearer_token.ToString());

            foreach (var item in headers)
            {
                if (_client.DefaultRequestHeaders.Contains(item.Key))
                    _client.DefaultRequestHeaders.Remove(item.Key);
                _client.DefaultRequestHeaders.Add(item.Key, item.Value);
            }
        }

        /// <summary>
        /// Get URL async
        /// </summary>
        /// <typeparam name="TReturnMessage"></typeparam>
        /// <param name="fullUrl"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public virtual async Task<TReturnMessage> GetAsync<TReturnMessage>(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddHeader(headers);

            var response = await _client.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return default;
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }
        /// <summary>
        /// Get File Async
        /// </summary>
        /// <typeparam name="TReturnMessage"></typeparam>
        /// <param name="fullUrl"></param>
        /// <param name="headers"></param>
        /// <returns></returns>
        public virtual async Task<byte[]> GetFileAsync<TReturnMessage>(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            _client.DefaultRequestHeaders.Accept.Clear();

            AddHeader(headers);

            var response = await _client.GetAsync(uri);
            if (!response.IsSuccessStatusCode) return null;
            var result = await response.Content.ReadAsByteArrayAsync();
            return result;
        }

        public virtual async Task<TReturnMessage> PostAsync<TReturnMessage>(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers)
            where TReturnMessage : class, new()
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);
            var response =
                await _client.PostAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));


            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return await Task.FromResult(new TReturnMessage());
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<TReturnMessage> PostAsync<TReturnMessage>(string fullUrl, HttpContent dataContent,
            Dictionary<string, string> headers)
            where TReturnMessage : class, new()
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);
            var response =
                await _client.PostAsync(uri, dataContent);

            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return await Task.FromResult(new TReturnMessage());
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<TReturnMessage> PutAsync<TReturnMessage>(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers = null)
            where TReturnMessage : class, new()
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);

            var response =
                await _client.PutAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return await Task.FromResult(new TReturnMessage());
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<TReturnMessage> DeleteAsync<TReturnMessage>(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);
            var response = await _client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();

            if (!response.IsSuccessStatusCode) return default(TReturnMessage);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TReturnMessage>(result);
        }

        public virtual async Task<HttpResponseMessage> GetAsync(string fullUrl,
           Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            AddHeader(headers);

            return await _client.GetAsync(uri);
        }
        public virtual async Task<HttpResponseMessage> GetFileAsync(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            _client.DefaultRequestHeaders.Accept.Clear();

            AddHeader(headers);

            return await _client.GetAsync(uri);
        }

        public virtual async Task<HttpResponseMessage> PostAsync(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);
            return await _client.PostAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));
        }

        public virtual async Task<HttpResponseMessage> PostAsync(string fullUrl, HttpContent dataContent,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);
            return await _client.PostAsync(uri, dataContent);
        }

        public virtual async Task<HttpResponseMessage> PutAsync(string fullUrl, string jsonStringData,
            Dictionary<string, string> headers = null)
        {
            var uri = GetUri(fullUrl);

            AddHeader(headers);

            return await _client.PutAsync(uri, new StringContent(jsonStringData, Encoding.UTF8, "application/json"));
        }

        public virtual async Task<HttpResponseMessage> DeleteAsync(string fullUrl,
            Dictionary<string, string> headers)
        {
            var uri = GetUri(fullUrl);
            AddHeader(headers);
            return await _client.DeleteAsync(uri);
        }
    }
}
