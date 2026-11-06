using MovieDatabase.Models;

namespace MovieDatabase.Services;

public class HorrorMovieStorage : JsonMovieStorage<HorrorMovie>
{
    public override string CategoryName => "Horror";

    public HorrorMovieStorage(string filePath) : base(filePath) { }

    protected override int GetId(HorrorMovie movie) => movie.Id;
}