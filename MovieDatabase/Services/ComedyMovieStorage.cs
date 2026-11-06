using MovieDatabase.Models;

namespace MovieDatabase.Services;

public class ComedyMovieStorage : JsonMovieStorage<ComedyMovie>
{
    public override string CategoryName => "Comedy";

    public ComedyMovieStorage(string filePath) : base(filePath) { }

    protected override int GetId(ComedyMovie movie) => movie.Id;
}