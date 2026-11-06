namespace MovieDatabase.Services;

public static class MovieStorageExtensions
{
    public static void Save<T>(this IEnumerable<IMovieStorage> storages, T movie)
    {
        var targetStorage = storages.OfType<IMovieStorage<T>>().FirstOrDefault();
        
        if (targetStorage != null)
        {
            targetStorage.Save(movie);
        }
        else
        {
            throw new InvalidOperationException($"No storage found for movie type: {typeof(T).Name}");
        }
    }
}