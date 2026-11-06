using MovieDatabase.Models;

namespace MovieDatabase.Services;

// Non-generic base interface allowing heterogenous collections (List<IMovieStorage>)
public interface IMovieStorage
{
    string CategoryName { get; }
    IEnumerable<object> FindAllUntyped();
}

public interface IMovieStorage<T> : IMovieStorage
{
    void Save(T movie);
    T? FindById(int id);
    List<T> FindAll();
}