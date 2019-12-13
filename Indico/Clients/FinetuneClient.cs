using Indico.Clients;
using Indico.Constants;
using Indico.Enums;
using Indico.Models.Async;
using Indico.Models.Finetune;
using Indico.Properties;
using Indico.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Indico.Clients
{
    internal class FinetuneApiClient : AsyncApiClient
    {
        private const int pollDelay = 2000;

        public FinetuneApiClient(string apiKey, string host) : base(apiKey, host) { }


        /// <summary>
        /// Gets info for a finetune collection
        /// </summary>
        /// <param name="collectionName">Name of the collection</param>
        /// <returns>Finetune Collection object describing the details and status of the collection.</returns>
        public async Task<FinetuneCollection> Info(string collectionName)
        {
            FinetuneRequest requestBody = new FinetuneRequest(APIKey, collectionName);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.CollectionInfo, FinetuneRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<FinetuneCollectionResponse>(responseBody).Results;
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
            finally
            {
                if (response != null) response.Dispose();
            }
        }


        /// <summary>
        /// Loads a finetune collection into memory for useage.
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to load</param>
        /// <returns>An object describing the custom collection</returns>
        public async Task<FinetuneCollection> Load(string collectionName)
        {
            // If the collection is already ready, don't re-load.
            FinetuneCollection collectionInfo = await this.Info(collectionName);
            if (collectionInfo.LoadStatus == "ready")
            {
                return collectionInfo;
            }

            // Kick off load job
            string jobID = await StartModelLoad(collectionName);

            while (true)
            {
                await Task.Delay(pollDelay);
                AsyncJobStatus jobStatus = await GetStatus(jobID);
                if (jobStatus == AsyncJobStatus.Success)
                {
                    break;
                }
                else if (jobStatus == AsyncJobStatus.Failure || jobStatus == AsyncJobStatus.Revoked)
                {
                    throw new IndicoAPIException("Load Failed");
                }
            }

            return await GetResults<FinetuneCollection>(jobID);
        }


        /// <summary>
        /// Kicks off model load job
        /// </summary>
        /// <param name="request">Request object to be sent to the load endpoint</param>
        /// <returns>Job ID string</returns>
        private async Task<string> StartModelLoad(string collectionName)
        {
            FinetuneRequest loadModelRequest = new FinetuneRequest(APIKey, collectionName)
            {
                StartJob = true
            };
            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.LoadCollection, FinetuneRequest.StringContentFromObject(loadModelRequest));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JobStartResponse>(responseBody).Results;
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
            finally
            {
                if (response != null) response.Dispose();
            }
        }


        /// <summary>
        /// Batch annotation predictions for a set of data.
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to predict with</param>
        /// <param name="examples">Array of strings to get predictions for</param>
        /// <returns></returns>
        public async Task<List<List<FinetuneExtraction>>> PredictAnnotation(string collectionName, string[] examples)
        {
            string jobID = await StartPrediction(collectionName, examples);

            while (true)
            {
                await Task.Delay(pollDelay);
                AsyncJobStatus jobStatus = await GetStatus(jobID);
                if (jobStatus == AsyncJobStatus.Success)
                {
                    break;
                }
                else if (jobStatus == AsyncJobStatus.Failure || jobStatus == AsyncJobStatus.Revoked)
                {
                    throw new IndicoAPIException("Prediction Failed");
                }
            }

            return await GetResults<List<List<FinetuneExtraction>>>(jobID);
        }


        /// <summary>
        /// Kicks off a prediction job
        /// </summary>
        /// <param name="request">Request object to be sent to the predict endpoint</param>
        /// <returns>Job ID string</returns>
        private async Task<string> StartPrediction(string collectionName, string[] examples)
        {
            FinetuneRequest predictRequest = new FinetuneRequest(APIKey, collectionName)
            {
                StartJob = true,
                Data = examples
            };
            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Predict, FinetuneRequest.StringContentFromObject(predictRequest));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JobStartResponse>(responseBody).Results;
            }
            catch (HttpRequestException hre)
            {
                throw new IndicoAPIException(Resources.Application_API_Request_Failure, hre);
            }
            finally
            {
                if (response != null) response.Dispose();
            }
        }
    }
}
