using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Indico.Custom.Properties;

namespace Indico.Custom
{
    /// <summary>
    /// The Application class holds an HTTP Client and list of API calls shared amongst the scope and child activities.
    /// </summary>
    public class Application
    {
        #region Properties

        private HttpClient Client { get; set; }
        private string APIKey { get; set; }
        private string URL { get; }

        #endregion


        #region Constructors

		// Creates a new, blank Application
		public Application() { }

        // Creates a new Application
        public Application(string apiKey, string indicoAPIURL)
        {
            APIKey = apiKey;
            URL = indicoAPIURL;
            CreateClient();
        }

        // Once authentication is complete, creates a reusable HTTP Client
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
                throw new IndicoAPIException(Resources.Application_CreateClient_InvalidURLException, eq);
            }
            catch (AggregateException ev)
            {
                throw new IndicoAPIException(Resources.Application_CreateClient_ServerUnreachableException, ev);
            }
        }

        #endregion


        #region Action Calls

        public Task<int> SumValues(int firstValue, int secondValue)
        {
            return Task.FromResult(firstValue + secondValue);
        }

        #endregion
    }
}
