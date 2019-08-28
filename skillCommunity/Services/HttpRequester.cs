using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using skillCommunity;

namespace YouWeesh.Mobile.Services
{
	/// <summary>
	/// Singleton, HttpRequester
	/// </summary>
	public sealed class HttpRequester
	{
		private HttpClient client;
		private HttpClientHandler handler;
		private string baseAdress;
		private static readonly Lazy<HttpRequester> lazy = new Lazy<HttpRequester>(() => new HttpRequester());
		public static HttpRequester Instance { get { return lazy.Value; } }
        private string baseUrl = "http://192.168.233.133:8000/";

        public HttpClient Client
		{
			get
			{
				return client;
			}

			set
			{
				client = value;
			}
		}

		private HttpRequester()
		{
			Client = new HttpClient();
			handler = new HttpClientHandler();
            Client.Timeout = TimeSpan.FromSeconds(60);
            //client.MaxResponseContentBufferSize = 256000;
			Client.BaseAddress = new Uri(baseUrl);
			Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Add("Accept", "application/json; version=1.0");
        }

        public async Task<HttpResponseMessage> PostAsync(string _methodName, params KeyValuePair<string, string>[] parameters)
        {
            //this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
            try
            {
                if (parameters.Length > 0)
                {
                    var content = new FormUrlEncodedContent(parameters);
                    var response = await Client.PostAsync(_methodName, content);

                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }



		public async Task<HttpResponseMessage> PostAsyncForUpdatingPicture(string _methodName, params KeyValuePair<string, string>[] parameters)
		{
            var dict = new Dictionary<string, string>();
            //this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
            try
            {
                for (int i = 0; i < parameters.Length; i++)
                {
                    dict.Add(parameters[i].Key, parameters[i].Value);
                }

                var jsonString = JsonConvert.SerializeObject(dict);
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                if (parameters.Length > 0)
                {
                    var response = await Client.PostAsync(_methodName, content);

                    return response;
                }
                else
                {
                    return null;
                }
            }catch(Exception ex)
            {
                return null;
            }
		}

		/// <summary>
		/// Generic Get call
		/// </summary>
		/// <returns>HttpResponseMessage</returns>
		/// <param name="_methodName">Method name.</param>
		public async Task<HttpResponseMessage> GetAsync(string _methodName) {
            try
            {
                /*
                if (!String.IsNullOrEmpty(App.Token))
                {
                    this.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", App.Token);
                }*/
                var response = await Client.GetAsync(_methodName);
                return response;
            }catch(Exception ex){
                return null;
            }
		}

        public async Task<HttpResponseMessage> GetAsyncExt(string _baseAddress)
        {
            try
            {
                HttpClient cl = new HttpClient();
                var uri = new Uri(_baseAddress);
                var response = await cl.GetAsync(uri);
                return response;
            }
            catch (Exception ex)
            {
                return null;
            }
        }



	}
}
