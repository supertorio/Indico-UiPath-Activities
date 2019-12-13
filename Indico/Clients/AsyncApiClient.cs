using Indico.Constants;
using Indico.Enums;
using Indico.Models;
using Indico.Models.Async;
using Indico.Properties;
using Indico.Tools;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Indico.Clients
{
    internal class AsyncApiClient : ApiClient
    {

        public AsyncApiClient(string apiKey, string host) : base(apiKey, host) { }

        public async Task<AsyncJobStatus> GetStatus(string jobId)
        {
            IndicoRequest requestBody = new IndicoRequest(APIKey);
            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(string.Format(Endpoints.JobStatus, jobId), IndicoRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JobStatusResponse>(responseBody).Results;
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


        public async Task<T> GetResults<T>(string jobId)
        {
            IndicoRequest requestBody = new IndicoRequest(APIKey);
            HttpResponseMessage response = null;

            try
            {
                response = await Client.PostAsync(string.Format(Endpoints.JobResult, jobId), IndicoRequest.StringContentFromObject(requestBody));
                HTTPMagic.CheckStatus(response);
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<JobResultsResponse<T>>(responseBody).Results;
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
