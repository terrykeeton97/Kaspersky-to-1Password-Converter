using System.Text;

namespace KCSV
{
    internal class CsvConverter
    {
        public string ConvertToCsv(List<CsvModel> data)
        {
            var csv = new StringBuilder();

            foreach (var row in data)
            {
                csv.AppendLine($"{EscapeCsvField(row.Title)},{EscapeCsvField(row.Website)},{EscapeCsvField(row.Username)}," +
                               $"{EscapeCsvField(row.Password)},{EscapeCsvField(row.Notes)}");
            }

            return csv.ToString();
        }

        private string EscapeCsvField(string field)
        {
            if (field == null) return string.Empty;
            if (field.Contains("\"")) field = field.Replace("\"", "\"\"");
            if (field.Contains(",")) field = $"\"{field}\"";
            return field;
        }
    }
}
