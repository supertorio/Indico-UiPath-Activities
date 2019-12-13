namespace Indico.Constants
{
    public static class Endpoints
    {
        public static string Collections => "/custom/collections";
        public static string CollectionInfo => "/custom/info";
        public static string AddData => "/custom/add_data";
        public static string RemoveData => "/custom/remove_example";
        public static string Train => "/custom/train";
        public static string Predict => "/custom/predict";
        public static string Explain => "/custom/explain";
        public static string DeleteCollection => "/custom/clear_collection";
        public static string RegisterCollection => "/custom/register";
        public static string DeRegisterCollection => "/custom/deregister";
        public static string AuthorizeUser => "/custom/authorize";
        public static string DeAuthorizeUser => "/custom/deauthorize";
        public static string LoadCollection => "/custom/load";
        public static string PdfExtraction => "/pdfExtraction";
        public static string JobStatus => "/async/{0}/status";
        public static string JobResult => "/async/{0}";
    }
}
