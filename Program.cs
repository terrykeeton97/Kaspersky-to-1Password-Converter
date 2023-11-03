using KCSV;
using System.Text;

class Program
{
    enum ParsingState
    {
        None,
        WebsiteName,
        WebsiteURL,
        Login,
        Password
    }

    static void Main(string[] args)
    {
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: Program.exe <InputFile> <OutputFile>");
            return;
        }

        var inputFilePath = args[0];
        var outputFilePath = args[1];

        if (!File.Exists(inputFilePath))
        {
            Console.WriteLine($"File \"{inputFilePath}\" not found");
            return;
        }

        var data = new List<CsvModel>();
        var currentRow = new CsvModel();

        using var reader = new StreamReader(inputFilePath);
        var line = string.Empty;

        while ((line = reader.ReadLine()) != null)
        {
            ParsingState currentState;
            switch (line.Split(':')[0].Trim())
            {
                case "Website name":
                    currentState = ParsingState.WebsiteName;
                    currentRow = new CsvModel();
                    currentRow.Title = line.Replace("Website name: ", "").Trim();
                    break;

                case "Website URL":
                    currentState = ParsingState.WebsiteURL;
                    if (currentRow != null) currentRow.Website = line.Replace("Website URL: ", "").Trim();
                    break;

                case "Login":
                    currentState = ParsingState.Login;
                    if (currentRow != null) currentRow.Username = line.Replace("Login: ", "").Trim();
                    break;

                case "Password":
                    currentState = ParsingState.Password;
                    if (currentRow != null)
                    {
                        currentRow.Password = line.Replace("Password: ", "").Trim();
                        data.Add(currentRow);
                        currentRow = null;
                    }
                    break;

                default: break;
            }
        }
        var converter = new CsvConverter();
        var csvData = converter.ConvertToCsv(data);

        try
        {
            using (var writer = new StreamWriter(outputFilePath, false, Encoding.UTF8))
            {
                writer.Write(csvData);
            }
            Console.WriteLine("Conversion finished - " + data.Count + " converted accounts");
        }
        catch (IOException ex)
        {
            Console.WriteLine("Error writing to output file: " + ex.Message);
        }

        Console.ReadLine();
    }
}
