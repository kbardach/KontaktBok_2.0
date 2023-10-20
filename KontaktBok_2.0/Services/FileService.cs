namespace KontaktBok_2._0.Services;

public class FileService
{
    //filePath är en variabel som pekar till sök vägen på mitt skrivbord
    private static readonly string filePath = @"C:\\Users\\kimba\\OneDrive\\Desktop\myContactBook.json";

    public static void SaveToFile(string contentAsJson)
    {
        try
        {
            using var sw = new StreamWriter(filePath);
            sw.Write(contentAsJson);
        }
        catch { }
    }

    public static string ReadFromFile()
    {
        try
        {
            if (File.Exists(filePath))
            {
                using var sr = new StreamReader(filePath);
                return sr.ReadToEnd();
            }
            else
                return null!;
        }
        catch { return null!; }
    }

}
