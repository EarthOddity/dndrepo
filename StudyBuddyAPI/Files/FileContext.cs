using System.Text.Json;

public class FileContext
{
   private const string filepath = "data.json";
   private DataContainer dataContainer = new();
   public List<Student> Students {get {LoadData(); return dataContainer.Students;}}

   public async Task SaveChangesAsync()
   {
        JsonSerializerOptions option = new()
        {
            WriteIndented = true
        };
        var data = JsonSerializer.Serialize(dataContainer, option);
        await File.WriteAllTextAsync(filepath, data);
   }

    public void LoadData()
    {
         if (!File.Exists(filepath))
         {
          dataContainer = new()
          {
            Students = [],
            Moderators = []

          };
          return; 
         }
         var content = File.ReadAllText(filepath);
         dataContainer = JsonSerializer.Deserialize<DataContainer>(content) ?? new();
    }
}