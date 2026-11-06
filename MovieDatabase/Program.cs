using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase;

internal class Program
{
    private static void Main(string[] args)
    {
        // it saves in .../RiderProjects/MovieDatabase/MovieDatabase/bin/debug/net10.0/MovieDatabase
        var horrorFilePath = Path.Combine("data", "horror-movies.json");

        IMovieStorage<HorrorMovie> horrorMovieStorage = new HorrorMovieStorage(horrorFilePath);

        Console.WriteLine("Hello, World!");
    }
}