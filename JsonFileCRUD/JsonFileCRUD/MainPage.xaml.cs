using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using JsonFileCRUD.Models;
using System.Text.Json;

namespace JsonFileCRUD;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
}
public partial class MainPageVM : ObservableObject
{
    [ObservableProperty]
    private string dataResourceText;

    [ObservableProperty]
    private UserM[] users;

    public MainPageVM()
    {
        Task.Run(ReadFile);
    }

    [RelayCommand]
    private void InitText()
    {
        var users = new List<UserM>()
                            {
                                new UserM(){Id=1,FirstName="Zekiri",LastName="Abdelali"},
                                new UserM(){Id=2,FirstName="Aloui",LastName="Ali"}
                            };

        DataResourceText = JsonSerializer.Serialize(users);
    }

    private async Task ReadFile()
    {
        try
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "data.json");
            if (!File.Exists(path))
            {
                using StreamWriter file = new StreamWriter(path);
            }
            using (StreamReader sr = File.OpenText(path))
            {
                DataResourceText = await sr.ReadToEndAsync();
                Users = JsonSerializer.Deserialize<UserM[]>(DataResourceText);
            }
        }
        catch (FileNotFoundException ex)
        {
            DataResourceText = ex.Message;
        }
    }

    [RelayCommand]
    private async Task WriteFile()
    {
        try
        {
            string path = Path.Combine(FileSystem.AppDataDirectory, "data.json");
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine(DataResourceText);
            }

            using (StreamReader sr = File.OpenText(path))
            {
                DataResourceText = await sr.ReadToEndAsync();
                Users = JsonSerializer.Deserialize<UserM[]>(DataResourceText);
            }
        }
        catch (FileNotFoundException ex)
        {
            DataResourceText = ex.Message;
        }
    }
}










/*
private async Task OnInitializedAsync()
{
    try
    {
        using var stream = await FileSystem.OpenAppPackageFileAsync("data.txt");
        using var reader = new StreamReader(stream);
        DataResourceText = await reader.ReadToEndAsync();
    }
    catch (Exception ex)
    {
        DataResourceText = ex.ToString();
    }
}
*/