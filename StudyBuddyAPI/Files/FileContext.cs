using System.Text.Json;

public class FileContext
{
    private const string filepath = "data.json";
    public DataContainer dataContainer = new();
    private bool isDataLoaded = false;

    public List<Student> Students
    {
        get
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }
            return dataContainer.Students;
        }
    }
    public List<Moderator> Moderators
    {
        get
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }
            return dataContainer.Moderators;
        }
    }
    public List<Subject> Subjects
    {
        get
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }
            return dataContainer.Subjects;
        }
    }

    public List<Bachelor> Bachelors
    {
        get
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }
            return dataContainer.Bachelors;
        }
    }

    public List<Calendar> Calendars
    {
        get
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }
            return dataContainer.Calendars;
        }
    }

    public List<Event> Events
    {
        get
        {
            if (!isDataLoaded)
            {
                LoadData();
                isDataLoaded = true;
            }
            return dataContainer.Events;
        }
    }
    public async Task SaveChangesAsync()
    {
        JsonSerializerOptions options = new()
        {
            WriteIndented = true
        };
        var data = JsonSerializer.Serialize(dataContainer, options);
        await File.WriteAllTextAsync(filepath, data);
    }

    public void LoadData()
    {
        if (!File.Exists(filepath))
        {
            dataContainer = new()
            {
                Students = [],
                Moderators = [],
                Subjects = [],
                Bachelors = [],
                Calendars = [],
                Events = [],

            };
            return;
        }
        var content = File.ReadAllText(filepath);
        dataContainer = JsonSerializer.Deserialize<DataContainer>(content) ?? new();
    }
}