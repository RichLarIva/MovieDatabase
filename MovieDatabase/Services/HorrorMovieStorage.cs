using System.Text.Json;
using MovieDatabase.Models;

namespace MovieDatabase.Services;

public class HorrorMovieStorage : IMovieStorage<HorrorMovie>
{
    private readonly string filePath;

    public HorrorMovieStorage(string filePath)
    {
        this.filePath = filePath;

        // Automatically creates the 'data' directory if it doesn't exist
        var directoryPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directoryPath)) Directory.CreateDirectory(directoryPath);
    }

    public void Save(HorrorMovie movie)
    {
        var movies = FindAll();

        // Check if a movie with this ID already exists
        if (movies.Any(m => m.Id == movie.Id))
            return;
        
        movies.Add(movie);
        SaveAll(movies);
    }

    public HorrorMovie? FindById(int id)
    {
        return FindAll().FirstOrDefault(m => m.Id == id);
    }

    public List<HorrorMovie> FindAll()
    {
        if (!File.Exists(filePath)) return new List<HorrorMovie>();

        var jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<List<HorrorMovie>>(jsonString) ?? new List<HorrorMovie>();
    }

    private void SaveAll(List<HorrorMovie> movies)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(movies, options);
        File.WriteAllText(filePath, jsonString);
    }
}