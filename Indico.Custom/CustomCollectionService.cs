using Indico.Custom.Constants;
using Indico.Custom.Enums;
using Indico.Custom.Models;
using Indico.Custom.Properties;
using Indico.Custom.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
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

        /// <summary>
        /// Performs the http post request to the list collections endpoint
        /// </summary>
        /// <returns>List of Custom Collection objects</returns>
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

        /// <summary>
        /// Returns full informaiton set for a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to fetch</param>
        /// <returns>An object describing the custom collection</returns>
        public async Task<CollectionResponse> GetCollectionInfo(string collectionName)
        {
            IndicoRequest requestBody = new IndicoRequest(APIKey, collectionName);

            try
            {
                HttpResponseMessage response = await Client.PostAsync(Endpoints.CollectionInfo, IndicoRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionResponse>(responseBody);
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
        }

        /// <summary>
        /// Performs a http post request to the add data endpoint
        /// </summary>
        /// <param name="labeledData">list of labeled data points</param>
        /// <param name="domain">the model domain to be used</param>
        /// <returns>Boolean value representing if the data was successfully added to the collection</returns>
        public async Task<AddDataResponse> AddCollectionsData(string collectionName, List<CollectionData> labeledData, ModelDomain domain)
        {
            AddDataRequest requestBody = new AddDataRequest(APIKey, collectionName, domain, labeledData);

            try
            {
                HttpResponseMessage response = await Client.PostAsync(Endpoints.AddData, IndicoRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<AddDataResponse>(responseBody);
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
        }


        /// <summary>
        /// Initiates a train on a custom collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to fetch</param>
        /// <returns>An object describing the status custom collection</returns>
        public async Task<CollectionResponse> StartTrainCollection(string collectionName)
        {
            IndicoRequest requestBody = new IndicoRequest(APIKey, collectionName);

            try
            {
                HttpResponseMessage response = await Client.PostAsync(Endpoints.Train, IndicoRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionResponse>(responseBody);
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
        }
    }
}
