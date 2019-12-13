using Indico.Clients;
using Indico.Enums;
using Indico.Models.Custom;
using Indico.Models.Finetune;
using Indico.Models.PDFExtraction;
using Indico.Properties;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Indico
{
    /// <summary>
    /// The Application class holds an HTTP Client and list of API calls shared amongst the scope and child activities.
    /// </summary>
    public class Application
    {
        #region Properties
        private string APIKey { get; }
        private string URL { get; }

        private CustomApiClient customApiClient { get; }
        private FinetuneApiClient finetuneApiClient { get; }
        private ExtractPDFClient extractPDFClient { get; }
        #endregion


        #region Constructors

        // Creates a new, blank Application
        public Application() { }

        // Creates a new Application
        public Application(string apiKey, string indicoAPIURL)
        {
            APIKey = apiKey;
            URL = indicoAPIURL;

            customApiClient = new CustomApiClient(APIKey, URL);
            finetuneApiClient = new FinetuneApiClient(APIKey, URL);
            extractPDFClient = new ExtractPDFClient(APIKey, URL);
        }

        #endregion


        #region Action Calls

        public async Task<List<CustomCollection>> GetCustomCollections()
        {
            return await customApiClient.ListAll();
        }

        public async Task<CustomCollection> GetCustomCollection(string collectionName)
        {
            return await customApiClient.Info(collectionName);
        }

        public async Task<bool> DeleteCustomCollection(string collectionName)
        {
            return await customApiClient.Delete(collectionName);
        }

        public async Task<bool> AddCustomCollectionData(string collectionName, List<CollectionData> labeledData, ModelDomain collectionDomain = ModelDomain.Standard)
        {
            return await customApiClient.AddData(collectionName, labeledData, collectionDomain);
        }

        public async Task<bool> RemoveCustomCollectionData(string collectionName, string[] examples)
        {
            return await customApiClient.RemoveData(collectionName, examples);
        }

        public async Task<CustomCollection> TrainCustomCollection(string collectionName)
        {
            return await customApiClient.Train(collectionName);
        }

        public async Task<List<Dictionary<string, float>>> GetCustomPredictions(string collectionName, string[] examples)
        {
            return await customApiClient.PredictClassification(collectionName, examples);
        }

        public async Task<List<List<AnnotationPrediction>>> GetCustomAnnotationPredictions(string collectionName, string[] examples)
        {
            return await customApiClient.PredictAnnotation(collectionName, examples);
        }

        public async Task<List<PredictionExplanation>> GetCustomExplanations(string collectionName, string[] examples)
        {
            return await customApiClient.Explain(collectionName, examples);
        }

        public async Task<bool> RegisterCustomCollection(string collectionName, bool isPublic)
        {
            return await customApiClient.Register(collectionName, isPublic);
        }

        public async Task<bool> DeregisterCustomCollection(string collectionName)
        {
            return await customApiClient.DeRegister(collectionName);
        }

        public async Task<bool> AddUserToCustomCollection(string collectionName, string userEmail, CollectionPermission permission)
        {
            return await customApiClient.AuthorizeUser(collectionName, userEmail, permission);
        }

        public async Task<bool> RemoveUserFromCustomCollection(string collectionName, string userEmail)
        {
            return await customApiClient.DeAuthorizeUser(collectionName, userEmail);
        }

        public async Task<FinetuneCollection> GetFinetuneCollection(string collectionName)
        {
            return await finetuneApiClient.Info(collectionName);
        }

        public async Task<FinetuneCollection> LoadFinetuneCollection(string collectionName)
        {
            return await finetuneApiClient.Load(collectionName);
        }

        public async Task<List<List<FinetuneExtraction>>> GetFinetunePredictions(string collectionName, string[] examples)
        {
            return await finetuneApiClient.PredictAnnotation(collectionName, examples);
        }

        public async Task<ExtractedPDF> ExtractPDF(string inputFilePath, bool ocrFlag, bool textFlag, bool metadataFlag, bool tablesFlag, bool singleColumnFlag)
        {
            string fileData = this.FileToBase64String(inputFilePath, Resources.PdfDataArgumentDisplayName);
            return await extractPDFClient.ExtractPDF(fileData, ocrFlag, textFlag, metadataFlag, tablesFlag, singleColumnFlag);
        }

        #endregion


        #region Helpers

        string FileToBase64String(string inputFilePath, string inputLabel)
        {
            if (!File.Exists(inputFilePath))
            {
                throw new ArgumentException(Resources.Application_FileDoesNotExistException, inputLabel);
            }

            byte[] fileAsBytes = File.ReadAllBytes(inputFilePath);
            return Convert.ToBase64String(fileAsBytes);
        }

        #endregion
    }
}
