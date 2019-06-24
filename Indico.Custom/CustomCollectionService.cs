using Indico.Custom.Constants;
using Indico.Custom.Models;
using Indico.Custom.Properties;
using Indico.Custom.Tools;
using Indico.Pretrained.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Indico.Custom
{
    class CustomCollectionService
    {
        private HttpClient Client { get; set; }
        private string APIKey { get; set; }


        public CustomCollectionService(HttpClient client, string apiKey)
        {
            Client = client;
            APIKey = apiKey;
        }

        public async Task<CollectionsResponse> GetCollectionsList()
        {
            IndicoRequest requestBody = new IndicoRequest(APIKey);

            try
            {
                HttpResponseMessage response = await Client.PostAsync(Endpoints.Collections, IndicoRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionsResponse>(responseBody);
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
        }
        
    }
}
