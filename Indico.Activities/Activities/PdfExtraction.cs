using System;
using System.Activities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Indico.Activities.Properties;
using Indico.Models.PDFExtraction;

namespace Indico.Activities
{
    [LocalizedDisplayName(nameof(Resources.PdfExtractionDisplayName))]
    [LocalizedDescription(nameof(Resources.PdfExtractionDescription))]
    public class PdfExtraction : AsyncTaskCodeActivity<ExtractedPDF>
    {
        [LocalizedDisplayName(nameof(Resources.PdfDataArgumentDisplayName))]
        [LocalizedDescription(nameof(Resources.PdfDataArgumentDescription))]
        [LocalizedCategory(nameof(Resources.Input))]
        [RequiredArgument]
        public InArgument<string> Data { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfOCRFlagDisplayName))]
        [LocalizedDescription(nameof(Resources.PdfOCRFlagDescription))]
        [LocalizedCategory(nameof(Resources.Options))]
        [RequiredArgument]
        public InArgument<bool> OCR { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfTextFlagDisplayName))]
        [LocalizedDescription(nameof(Resources.PdfTextFlagDescription))]
        [LocalizedCategory(nameof(Resources.Options))]
        public InArgument<bool> Text { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfMetadataFlagDisplayName))]
        [LocalizedDescription(nameof(Resources.PdfMetadataFlagDescription))]
        [LocalizedCategory(nameof(Resources.Options))]
        public InArgument<bool> Metadata { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfTablesFlagDisplayName))]
        [LocalizedDescription(nameof(Resources.PdfTablesFlagDescription))]
        [LocalizedCategory(nameof(Resources.Options))]
        public InArgument<bool> Tables { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfSingleColumnDisplayName))]
        [LocalizedDescription(nameof(Resources.PdfSingleColumnDescription))]
        [LocalizedCategory(nameof(Resources.Options))]
        public InArgument<bool> SingleColumn { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfMetadatasDisplayName))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<Dictionary<string, object>> ExtractedMetadata { get; set; }

        [LocalizedDisplayName(nameof(Resources.PdfExtractedPagesDisplayName))]
        [LocalizedCategory(nameof(Resources.Output))]
        public OutArgument<List<PDFPage>> ExtractedPages { get; set; }

        public PdfExtraction()
        {
            OCR = false;
            Text = true;
            Metadata = false;
            Tables = false;
            SingleColumn = true;
        }

        protected override Task<ExtractedPDF> ExecuteAsync(AsyncCodeActivityContext context, CancellationToken cancellationToken, Application client)
        {
            var inputFilePath = Data.Get(context);

            if (string.IsNullOrWhiteSpace(inputFilePath))
            {
                throw new ArgumentNullException(Resources.PdfDataArgumentDisplayName);
            }

            var ocrFlag = OCR.Get(context);
            var textFlag = Text.Get(context);
            var metadataFlag = Metadata.Get(context);
            var tablesFlag = Tables.Get(context);
            var singleColumnFlag = SingleColumn.Get(context);
            return client.ExtractPDF(inputFilePath, ocrFlag, textFlag, metadataFlag, tablesFlag, singleColumnFlag);
        }

        protected override void OutputResult(AsyncCodeActivityContext context, ExtractedPDF response)
        {
            Dictionary<string, object> metadataResponse = Metadata.Get(context) ? response.Metadata : new Dictionary<string, object>();
            ExtractedPages.Set(context, response.Pages);
            ExtractedMetadata.Set(context, metadataResponse);
        }
    }
}
