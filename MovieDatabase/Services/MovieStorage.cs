using System.Collections.Generic;

namespace MovieDatabase.Services;

public interface iMovieStorage<T>
{
    void Save(T movie);
    T FindByID(int id);
    List<T> FindAll();
}