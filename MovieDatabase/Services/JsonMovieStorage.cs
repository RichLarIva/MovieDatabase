using System.Text.Json;

namespace MovieDatabase.Services;

public abstract class JsonMovieStorage<T> : IMovieStorage<T>
{
    private readonly string _filePath;

    public abstract string CategoryName { get; }

    protected JsonMovieStorage(string filePath)
    {
        _filePath = filePath;
        var directoryPath = Path.GetDirectoryName(filePath);
        if (!string.IsNullOrEmpty(directoryPath)) Directory.CreateDirectory(directoryPath);
    }

    protected abstract int GetId(T item);

    public void Save(T movie)
    {
        var movies = FindAll();
        if (movies.Any(m => GetId(m) == GetId(movie))) return;

        movies.Add(movie);
        SaveAll(movies);
    }

    public T? FindById(int id)
    {
        return FindAll().FirstOrDefault(m => GetId(m) == id);
    }

    public List<T> FindAll()
    {
        if (!File.Exists(_filePath)) return new List<T>();
        var jsonString = File.ReadAllText(_filePath);
        return JsonSerializer.Deserialize<List<T>>(jsonString) ?? new List<T>();
    }

    public IEnumerable<object> FindAllUntyped() => FindAll().Cast<object>();

    private void SaveAll(List<T> movies)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        var jsonString = JsonSerializer.Serialize(movies, options);
        File.WriteAllText(_filePath, jsonString);
    }
}