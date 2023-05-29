using Sales.Shared.Entities;
using System.Net.Http;
using System.Text.Json;

namespace Sales.Web.Repositories
{
    public class Repository : IRepository
    {
        private readonly HttpClient _HttpClient;
        public Repository(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }
        public async Task<HttpResponseWrapper<T>> GetItemsAsync<T>(string url)
            => await GetItemAsync<T>(url);


        public async Task<HttpResponseWrapper<T>> GetItemByIdAsync<T>(string url, int id)
            => await GetItemAsync<T>($"{url}/{id}");


        public async Task<HttpResponseWrapper<object>> PostAsync<T>(string url, T model)
        {
            //var _uri = $"{GlobalSetting.IdentityEndpointBase}/{controllerName}";
            var _postData = JsonSerializer.Serialize<T>(model);
            var _messageContent = new StringContent(_postData, System.Text.Encoding.UTF8, "application/json");
            var _responseHttp = await _HttpClient.PostAsync(url, _messageContent);
            return new HttpResponseWrapper<object>(null, !_responseHttp.IsSuccessStatusCode, _responseHttp);

        }

        public async Task<HttpResponseWrapper<TResponse>> PostAsync<T, TResponse>(string url, T model) 
        {
   
            var _postData = JsonSerializer.Serialize<T>(model);
            var _messageContent = new StringContent(_postData, System.Text.Encoding.UTF8, "application/json");
            var _responseHttp = await _HttpClient.PostAsync(url, _messageContent);
            if (_responseHttp.IsSuccessStatusCode) 
            {
                var _response = await UnserializeAnswer<TResponse>(_responseHttp, JsonDefaultOptions);
                return new HttpResponseWrapper<TResponse>(_response, false ,_responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(default, !_responseHttp.IsSuccessStatusCode, _responseHttp);


        }

        #region Prinvate functions


        private JsonSerializerOptions JsonDefaultOptions => new()
        {
            PropertyNameCaseInsensitive = true,
        };

        private async Task<T> UnserializeAnswer<T>(HttpResponseMessage httpResponse, JsonSerializerOptions jsonOption)
        {
            var _responseString = await httpResponse.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<T>(_responseString, jsonOption)!;
        }


        /// <summary>
        /// Get item or Items by full Url
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="uri"></param>
        /// <returns></returns>
        private async Task<HttpResponseWrapper<T>> GetItemAsync<T>(string uri) 
        {

            var _responseHttp = await _HttpClient.GetAsync(uri);
            if (_responseHttp.IsSuccessStatusCode)
            {
                var _reponse = await UnserializeAnswer<T>(_responseHttp, JsonDefaultOptions);
                return new HttpResponseWrapper<T>(_reponse, false, _responseHttp);
            }

            return new HttpResponseWrapper<T>(default, true, _responseHttp);
        }




        public async Task<HttpResponseWrapper<object>> DeleteAsync(string url, int id)
        {
         var _responseHttp = await _HttpClient.DeleteAsync($"{url}/{id}"); 

            return new HttpResponseWrapper<object> (null, !_responseHttp.IsSuccessStatusCode, _responseHttp);
        }

        public async Task<HttpResponseWrapper<object>> PutAsync<T>(string url, T model)
        {
            var _postData = JsonSerializer.Serialize<T>(model);
            var _messageContent = new StringContent(_postData, System.Text.Encoding.UTF8, "application/json");
            var _responseHttp = await _HttpClient.PutAsync(url, _messageContent);
            return new HttpResponseWrapper<object>(null, !_responseHttp.IsSuccessStatusCode, _responseHttp);
        }

        public async Task<HttpResponseWrapper<TResponse>> PutAsync<T, TResponse>(string url, T model)
        {
            var _postData = JsonSerializer.Serialize<T>(model);
            var _messageContent = new StringContent(_postData, System.Text.Encoding.UTF8, "application/json");
            var _responseHttp = await _HttpClient.PutAsync(url, _messageContent);
            if (_responseHttp.IsSuccessStatusCode)
            {
                var _response = await UnserializeAnswer<TResponse>(_responseHttp, JsonDefaultOptions);
                return new HttpResponseWrapper<TResponse>(_response, false, _responseHttp);
            }

            return new HttpResponseWrapper<TResponse>(default, !_responseHttp.IsSuccessStatusCode, _responseHttp);

        }


        #endregion

    }

}
