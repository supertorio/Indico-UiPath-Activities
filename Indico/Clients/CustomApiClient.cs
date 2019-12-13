using Indico.Constants;
using Indico.Enums;
using Indico.Models.Custom;
using Indico.Properties;
using Indico.Tools;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Indico.Clients
{
    internal class CustomApiClient : ApiClient
    {
        private const int DEFAULT_VERSION = 1;

        public CustomApiClient(string apiKey, string host) : base(apiKey, host) { }


        /// <summary>
        /// List all account custom collections
        /// </summary>
        /// <returns>List of Custom Collection objects</returns>
        public async Task<List<CustomCollection>> ListAll()
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Collections, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionsResponse>(responseBody).Results;
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
        /// Get info for a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to fetch</param>
        /// <returns>An object describing the custom collection</returns>
        public async Task<CustomCollection> Info(string collectionName)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.CollectionInfo, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionResponse>(responseBody).Results;
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
        /// Deletes a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to delete</param>
        /// <returns>True if successful</returns>
        public async Task<bool> Delete(string collectionName)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.DeleteCollection, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
        /// Adds Data to a collection with a supplied domain
        /// </summary>
        /// <param name="collectionName">Name of the collection to add data too</param>
        /// <param name="labeledData">list of labeled data points</param>
        /// <param name="domain">the model domain to be used</param>
        /// <returns>True if successful</returns>
        public async Task<bool> AddData(string collectionName, List<CollectionData> labeledData, ModelDomain domain)
        {
            AddDataRequest requestBody = new AddDataRequest(APIKey, collectionName, domain, labeledData);
            return await PerformAddData(requestBody);
        }

        /// <summary>
        /// Adds Data to a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to add data too</param>
        /// <param name="labeledData">list of labeled data points</param>
        /// <returns>True if successful</returns>
        public async Task<bool> AddData(string collectionName, List<CollectionData> labeledData)
        {
            AddDataRequest requestBody = new AddDataRequest(APIKey, collectionName, labeledData);
            return await PerformAddData(requestBody);
        }


        /// <summary>
        /// Runner for the AddData Methods
        /// </summary>
        /// <param name="requestBody"></param>
        /// <returns>True if successful</returns>
        private async Task<bool> PerformAddData(AddDataRequest requestBody)
        {
            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.AddData, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
        /// Removes Data from a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to train</param>
        /// <param name="examples">list of strings</param>
        /// <returns>True if successful</returns>
        public async Task<bool> RemoveData(string collectionName, string[] examples)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName, examples);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.RemoveData, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
        /// Initiates train on a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to train</param>
        /// <returns>An object describing the status custom collection</returns>
        public async Task<CustomCollection> Train(string collectionName)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Train, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CollectionResponse>(responseBody).Results;
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
        /// Batch predict on a classification collection
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to use for prediction</param>
        /// <param name="examples">Array of strings to get predictions for</param>
        /// <param name="version">API Version</param>
        /// <returns>An array of dictioaries of prediction values for each example supplied</returns>
        public async Task<List<Dictionary<string, float>>> PredictClassification(string collectionName, string[] examples, int version = DEFAULT_VERSION)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName, examples)
            {
                Version = version
            };

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Predict, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BatchPredictResponse>(responseBody).Results;
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
        /// Batch predict on an annotation collection
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to use for prediction</param>
        /// <param name="examples">Array of strings to get predictions for</param>
        /// <param name="version">API Version</param>
        /// <returns>An list of annotation prediction objects for each sample</returns>
        public async Task<List<List<AnnotationPrediction>>> PredictAnnotation(string collectionName, string[] examples, int version = DEFAULT_VERSION)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName, examples)
            {
                Version = version
            };

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Predict, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BatchPredictAnnotationResponse>(responseBody).Results;
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
        /// Single example explain on a classification collection
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to use for explanation</param>
        /// <param name="example">String to get prediction explanations for</param>
        /// <param name="version">API Version</param>
        /// <returns>An explanation for the supplied example</returns>
        public async Task<PredictionExplanation> Explain(string collectionName, string example, int version = DEFAULT_VERSION)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName, example)
            {
                Version = version
            };

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Explain, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ExplainResponse>(responseBody).Results;
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
        /// Batch explain for a classification collection
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to use for explanation</param>
        /// <param name="examples">Array of strings to get prediction explanations for</param>
        /// <param name="version">API Version</param>
        /// <returns>An array of explanations for each example supplied</returns>
        public async Task<List<PredictionExplanation>> Explain(string collectionName, string[] examples, int version = DEFAULT_VERSION)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName, examples)
            {
                Version = version
            };

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.Explain, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<BatchExplainResponse>(responseBody).Results;
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
        /// Registers a collection for sharing
        /// </summary>
        /// <param name="collectionName">Name of the custom collection to register</param>
        /// <param name="isPublic">True if the collection should be set to public</param>
        /// <returns>True if succesfull</returns>
        public async Task<bool> Register(string collectionName, bool isPublic)
        {
            RegisterRequest requestBody = new RegisterRequest(APIKey, collectionName, isPublic);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.RegisterCollection, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
        /// Deregisters sharing for a collection 
        /// </summary>
        /// <param name="collectionName">Name of the collection to deregister</param>
        /// <returns>True if succesfull</returns>
        public async Task<bool> DeRegister(string collectionName)
        {
            IndicoCustomRequest requestBody = new IndicoCustomRequest(APIKey, collectionName);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.DeRegisterCollection, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
        /// Authorizes a user, by email, to have access to a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to grant permission</param>
        /// <param name="userEmail">Email of the user to grant permission to</param>
        /// <param name="permission">Which permission to assign</param>
        /// <returns>True if succesfull</returns>
        public async Task<bool> AuthorizeUser(string collectionName, string userEmail, CollectionPermission permission)
        {
            AuthorizeRequest requestBody = new AuthorizeRequest(APIKey, collectionName, userEmail, permission);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.AuthorizeUser, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
        /// Deuthorizes a user, by email, to have access to a collection
        /// </summary>
        /// <param name="collectionName">Name of the collection to revoke permission from</param>
        /// <param name="userEmail">Email of the user who's permission is being revoked</param>
        /// <returns>True if succesfull</returns>
        public async Task<bool> DeAuthorizeUser(string collectionName, string userEmail)
        {
            DeAuthorizeRequest requestBody = new DeAuthorizeRequest(APIKey, collectionName, userEmail);

            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.DeAuthorizeUser, IndicoCustomRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<SimpleResponse>(responseBody).Results;
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
