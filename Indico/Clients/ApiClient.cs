using Indico.Properties;
using Indico.Tools;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Indico.Clients
{
    internal class ApiClient
    {
        private readonly string URL;
        protected readonly string APIKey;

        protected HttpClient Client;


        public ApiClient(string apiKey, string host)
        {
            this.URL = host;
            this.APIKey = apiKey;
            this.CreateClient();
        }

        private void CreateClient()
        {
            if (URL == null) return;

            var cookies = new CookieContainer();
            var handler = new HttpClientHandler { CookieContainer = cookies };

            try
            {
                Client = new HttpClient(handler) { BaseAddress = new Uri(URL) };
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            }
            catch (UriFormatException eq)
            {
                throw new IndicoAPIException(Resources.Application_InvalidURLException, eq);
            }
            catch (AggregateException ev)
            {
                throw new IndicoAPIException(Resources.Application_ServerUnreachableException, ev);
            }
        }

    }
}
