using Newtonsoft.Json;
using System;

namespace Indico.Models.PDFExtraction
{
    [JsonObject()]
    public class PDFTableCell
    {
        [JsonProperty(PropertyName = "first_col")]
        public int FirstColumn { get; set; }

        [JsonProperty(PropertyName = "last_col")]
        public int LastColumn { get; set; }

        [JsonProperty(PropertyName = "first_row")]
        public int FirstRow { get; set; }

        [JsonProperty(PropertyName = "last_row")]
        public int LastRow { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text;

        public PDFTableCell()
        {
        }

        public string GetStartingCell()
        {
            string startingColumn = GetExcelColumnFromInt(this.FirstColumn + 1);
            int startingRow = this.FirstRow + 1;
            return startingColumn + startingRow.ToString();
        }

        public string GetCellRange()
        {
            string startingColumn = GetExcelColumnFromInt(this.FirstColumn + 1);
            int startingRow = this.FirstRow + 1;
            string endingColumn = GetExcelColumnFromInt(this.LastColumn + 1);
            int endingRow = this.LastRow + 1;
            return String.Format("{0}{1}:{2}{3}", startingColumn, startingRow, endingColumn, endingRow);
        }

        private static string GetExcelColumnFromInt(int colNumber)
        {
            string columnName = "";
            while (colNumber > 0)
            {
                int modulo = (colNumber - 1) % 26;
                columnName = (char)(65 + modulo) + columnName;
                colNumber = (colNumber - modulo) / 26;
            }
            return columnName;
        }
    }
}
