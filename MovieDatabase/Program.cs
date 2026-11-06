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

        var horrorMovie0 = new HorrorMovie("In The Mouth Of Madness", 123, new MovieRating(10.0));
        var horrorMovie1 = new HorrorMovie("The Silence of the Lambs", 316, new MovieRating(9.0));
        var horrorMovie2 = new HorrorMovie("The Thing", 5433, new MovieRating(8.0));
        var horrorMovie3 = new HorrorMovie("Scream", 11235, new MovieRating(6.0));
        var horrorMovie4 = new HorrorMovie("The Shining", 7523, new MovieRating(8.5));
        
        horrorMovieStorage.Save(horrorMovie0);
        horrorMovieStorage.Save(horrorMovie1);
        horrorMovieStorage.Save(horrorMovie2);
        horrorMovieStorage.Save(horrorMovie3);
        horrorMovieStorage.Save(horrorMovie4);
    }
}