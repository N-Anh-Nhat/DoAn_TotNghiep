using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using LIB.BaseModels;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace WebAdminShop.ApiCaller
{
    public partial class ApiClient
    {
        #region Variable

        private HttpClient _httpClient;

        private Uri BaseEndPoint { get; set; }
        
        #endregion

        #region Constructor

        public ApiClient(Uri baseEndPoint)
        {
            if (baseEndPoint == null)
            {
                throw new ArgumentException("BaseEndPoint NULL");
            }

            BaseEndPoint = baseEndPoint;

            _httpClient = new HttpClient();

        }

        #endregion

        #region Method

        private void AddHeaders(string accessToken)
        {
            if (!string.IsNullOrEmpty(accessToken))
            {
                _httpClient.DefaultRequestHeaders.Remove("Authorization");
                _httpClient.DefaultRequestHeaders.Add("Authorization",accessToken);
            }
        }

        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

        //Common call api method

        private async Task<T> GetAsync<T>(Uri requestUrl, JObject obj, string token)
        {
            AddHeaders(token);

            var request = new HttpRequestMessage
            {
                RequestUri = requestUrl,
                Method = HttpMethod.Get
            };

            request.Content = new StringContent(obj.ToString(), Encoding.UTF8, "application/json");
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.SendAsync(request);

            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }


        private async Task<T> GetAsync<T>(Uri requestUrl, string token = "")
        {
            AddHeaders(token);
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);

        }

        private async Task<Message<T>> PostAsync<T>(Uri requestUrl, T content, string token)
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = new Message<T>
            {
                Data = JsonConvert.DeserializeObject<T>(data),
                IsSuccess = response.IsSuccessStatusCode,
                ReturnMessage = response.ReasonPhrase
            };
            return returns;
        }
        private async Task<DataResults<T>> NewPostAsync<T>(Uri requestUrl, T content, string token)
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = JsonConvert.DeserializeObject<DataResults<T>>(data);            
            return returns;
        }
        private async Task<Message<T1>> PostAsync<T1, T2>(Uri requestUrl, T2 content, string token)
        {
            AddHeaders(token);
            var response = await _httpClient.PostAsync(requestUrl.ToString(), CreateHttpContent<T2>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            var returns = new Message<T1>
            {
                Data = JsonConvert.DeserializeObject<T1>(data),
                IsSuccess = response.IsSuccessStatusCode,
                ReturnMessage = response.ReasonPhrase
            };
            return returns;
        }

        private async Task<T> PutAsync<T>(Uri requestUrl, T content, string token)
        {
            AddHeaders(token);
            var response = await _httpClient.PutAsync(requestUrl.ToString(), CreateHttpContent<T>(content));
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async Task<T> DeleteAsync<T>(Uri requestUrl, string token)
        {
            AddHeaders(token);
            var response = await _httpClient.DeleteAsync(requestUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);

        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(BaseEndPoint, relativePath);
            var uriBuilder = new UriBuilder(endpoint);

            if (!string.IsNullOrEmpty(queryString))
            {
                uriBuilder.Query = queryString;
            }

            return uriBuilder.Uri;
        }

        public async Task<int> CheckToken(string token)
        {
            try
            {
                var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "CheckToken"));

                var data = await GetAsync<int>(requestUrl, token);

                return data;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        
        public async Task<string> GetTokenAsync()
        {
            var requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, "Token/GetToken?u=Admin&p=nhatphung&account=Admin"));

            var data = await GetAsync<string>(requestUrl);
            
            return data;
        }

        public async Task<string> RefeshToken(UserInfoModel userInfo)
        {

            
            if (userInfo != null)
            {
                var ck = await CheckToken(userInfo.token);

                if (ck != 0)
                {
                    return userInfo.token;
                }
                else
                {
                    string tokenNew = await GetTokenAsync();
                    return tokenNew;
                }
            }

            return string.Empty;
        }

        //send file parameter for api controller from video controller
        public async Task<Message<String>> PostFormDataAsync<T>(Uri url, string token, T data)
        {
            var content = new MultipartFormDataContent();
            AddHeaders(token);
            if (data is FormFile)
            {
                var file = data as FormFile;
                content.Add(new StreamContent(file.OpenReadStream()), file.Name, file.FileName);
                content.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data") { Name = file.Name, FileName = file.FileName };
            }
            var response = await _httpClient.PostAsync(url, content);
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            var returns = new Message<String>
            {
                Data = result,
                IsSuccess = response.IsSuccessStatusCode,
                ReturnMessage = response.ReasonPhrase
            };
            return returns;

        }
        private async Task<Stream> GetFileAsync(Uri requestUrl, string token = "")
        {
            AddHeaders(token);
            var response = await _httpClient.GetAsync(requestUrl, HttpCompletionOption.ResponseHeadersRead);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStreamAsync();
        }

        #endregion
    }
}
