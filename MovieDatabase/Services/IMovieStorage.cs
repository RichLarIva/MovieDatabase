using MovieDatabase.Models;

namespace MovieDatabase.Services;

public interface IMovieStorage<T>
{
    void Save(T movie);
    HorrorMovie? FindById(int id);
    List<T> FindAll();
}