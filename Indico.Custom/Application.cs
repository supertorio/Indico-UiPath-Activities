﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Indico.Custom.Enums;
using Indico.Custom.Models;
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
        private string APIKey { get; }
        private string URL { get; }

        private string CollectionName { get; }
        private ModelDomain CollectionDomain { get; }

        private CustomCollectionService collectionService { get; }
        #endregion


        #region Constructors

		// Creates a new, blank Application
		public Application() { }

        // Creates a new Application
        public Application(string apiKey, string indicoAPIURL, string collectionName, ModelDomain collectionDomain)
        {
            APIKey = apiKey;
            URL = indicoAPIURL;
            CollectionName = collectionName;
            CollectionDomain = collectionDomain;
            CreateClient();

            collectionService = new CustomCollectionService(Client, APIKey);
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

        /// <summary>
        /// Intantiates a call to the list collections endpoint
        /// </summary>
        /// <returns>Async Task Reponse Encapsulating the Collections Response</returns>
        public async Task<CollectionsResponse> GetCollections()
        {
            return await collectionService.GetCollectionsList();
        }

        /// <summary>
        /// Intantiates a call to be backend service to get the status of a given custom collection
        /// </summary>
        /// <returns>Async Task Response</returns>
        public async Task<CollectionResponse> GetCollection()
        {
            return await collectionService.GetCollectionInfo(CollectionName);
        }

        /// <summary>
        /// Initiates a call to the add data endpoint for the current collection
        /// </summary>
        /// <param name="labeledData">A list of labeled data points</param>
        /// <param name="domain">One of the available indico data domains</param>
        /// <returns>Async Task Response</returns>
        public async Task<AddDataResponse> AddCollectionsData(List<CollectionData> labeledData)
        {
            return await collectionService.AddCollectionsData(CollectionName, labeledData, CollectionDomain);
        }

        /// <summary>
        /// Initiates a call to the train endpoint for the current collection
        /// </summary>
        /// <returns></returns>
        public async Task<CollectionResponse> TrainCollection()
        {
            return await collectionService.StartTrainCollection(CollectionName);
        }


        #endregion
    }
}
