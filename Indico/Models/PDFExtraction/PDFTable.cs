using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;

namespace Indico.Models.PDFExtraction
{
    [JsonObject()]
    public class PDFTable
    {
        [JsonProperty(PropertyName = "cells")]
        public List<PDFTableCell> Cells { get; set; }

        [JsonProperty(PropertyName = "n_cols")]
        public int ColCount { get; set; }

        [JsonProperty(PropertyName = "n_rows")]
        public int RowCount { get; set; }

        public PDFTable()
        {
        }

        public DataTable AsDataTable()
        {
            DataTable table = new DataTable();
            for (int i = 0; i < ColCount; i++)
            {
                DataColumn column = new DataColumn();
                column.DataType = System.Type.GetType("System.String");
                column.ColumnName = "Col" + i.ToString();
                table.Columns.Add(column);
            }

            for (int i = 0; i < RowCount; i++)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
            }

            for (int i = 0; i < Cells.Count; i++)
            {
                int row = Cells[i].FirstRow;
                int col = Cells[i].FirstColumn;
                string contents = Cells[i].Text;
                table.Rows[row][col] = contents;
            }

            return table;
        }
    }
}
