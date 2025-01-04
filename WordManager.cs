using Newtonsoft.Json;

public class WordManager
{
    public List<string> Words { get; private set; }

    public WordManager(string filePath)
    {
        LoadWordsFromJson(filePath);
    }

    private void LoadWordsFromJson(string filePath)
    {
        try
        {
            string json = File.ReadAllText(filePath);
            Words = JsonConvert.DeserializeObject<List<string>>(json)!;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading JSON file: " + ex.Message);
            Words = new List<string>();
        }
    }

    public string GetRandomWord()
    {
        Random random = new Random();
        return Words[random.Next(Words.Count)];
    }
}