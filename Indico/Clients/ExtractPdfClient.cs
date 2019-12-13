using Indico.Clients;
using Indico.Constants;
using Indico.Enums;
using Indico.Models;
using Indico.Models.Async;
using Indico.Models.PDFExtraction;
using Indico.Properties;
using Indico.Tools;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Indico.Clients
{
    internal class ExtractPDFClient : AsyncApiClient
    {
        private const int pollDelay = 2000;

        public ExtractPDFClient(string apiKey, string host) : base(apiKey, host) { }

        /// <summary>
        /// Calls the indico api to extract a pdf via the jobs system
        /// </summary>
        /// <param name="inputValue">Base64 Encoded PDF File</param>
        /// <param name="ocrFlag">True to Perform OCR Extraction</param>
        /// <param name="textFlag">Return extracted page Text</param>
        /// <param name="metadataFlag">Return extracted document metata</param>
        /// <param name="tablesFlag">Return extracted tables</param>
        /// <param name="singleColumnFlag">True to treat the document as a single column of text.</param>
        /// <returns>Extracted PDF Object</returns>
        public async Task<ExtractedPDF> ExtractPDF(string inputValue, bool ocrFlag = false, bool textFlag = true, bool metadataFlag = false,
            bool tablesFlag = false, bool singleColumnFlag = true)
        {
            string jobID = await StartExtraction(inputValue, ocrFlag, textFlag, metadataFlag, tablesFlag, singleColumnFlag);

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

            return await GetResults<ExtractedPDF>(jobID);
        }


        
        private async Task<string> StartExtraction(string inputValue, bool ocrFlag = false, bool textFlag = true, bool metadataFlag = false,
            bool tablesFlag = false, bool singleColumnFlag = true)
        {
            ExtractPdfRequest requestBody = new ExtractPdfRequest(APIKey, inputValue, ocrFlag, textFlag, metadataFlag, tablesFlag, singleColumnFlag);
            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(Endpoints.PdfExtraction, IndicoRequest.StringContentFromObject(requestBody));
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
