using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase;

internal class Program
{
    private static readonly string Menu = "1. Show All Movies in one category\n" +
                                          "2. Show All Movies\n" +
                                          "0. Quit\n" +
                                          "Whats your choice: ";
    
    private static void Main(string[] args)
    {
        
        var storages = new List<IMovieStorage>
        {
            // it saves in .../RiderProjects/MovieDatabase/MovieDatabase/bin/debug/net10.0/MovieDatabase
            new HorrorMovieStorage(Path.Combine("data", "horror-movies.json")),
            new ComedyMovieStorage(Path.Combine("data", "comedy-movies.json"))
        };

        var horrorMovie0 = new HorrorMovie("In The Mouth Of Madness", 123, new MovieRating(10.0));
        var horrorMovie1 = new HorrorMovie("The Silence of the Lambs", 316, new MovieRating(9.0));
        var horrorMovie2 = new HorrorMovie("The Thing", 5433, new MovieRating(8.0));
        var horrorMovie3 = new HorrorMovie("Scream", 11235, new MovieRating(6.0));
        var horrorMovie4 = new HorrorMovie("The Shining", 7523, new MovieRating(8.5));
        
        var comedyMovie0 = new ComedyMovie("Superbad", 123, new MovieRating(7.6));
        var comedyMovie1 = new ComedyMovie("Scary Movie 1", 321, new MovieRating(6.8));
        var comedyMovie2 = new ComedyMovie("The Room", 531, new MovieRating(5.8));
        var comedyMovie3 = new ComedyMovie("Shaun of the Dead", 648, new MovieRating(7));
        var comedyMovie4 = new ComedyMovie("The Cable Guy", 3125, new MovieRating(5.2));

        storages.Save(horrorMovie0);
        storages.Save(horrorMovie1);
        storages.Save(horrorMovie2);
        storages.Save(horrorMovie3);
        storages.Save(horrorMovie4);
        
        storages.Save(comedyMovie0);
        storages.Save(comedyMovie1);
        storages.Save(comedyMovie2);
        storages.Save(comedyMovie3);
        storages.Save(comedyMovie4);
        
        bool running = true;

        while (running)
        {
            Console.Write(Menu);
            string? choice = Console.ReadLine()?.Trim().ToLower();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    ShowCategoryMovies(storages);
                    break;
                case "2":
                    ShowAllMovies(storages);
                    break;
                case "0":
                case "q":
                    Console.WriteLine("Exiting Application. Goodbye!");
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.\n");
                    break;
            }
        }
    }

    private static void ShowCategoryMovies(List<IMovieStorage> storages)
    {
        Console.WriteLine("Select a category:");
        for (int i = 0; i < storages.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {storages[i].CategoryName}");
        }

        Console.Write("Choice: ");

        if (int.TryParse(Console.ReadLine()?.Trim(), out int index) && index >= 1 && index <= storages.Count)
        {
            var storage = storages[index - 1];
            DisplayMovies($"{storage.CategoryName} Movies", storage.FindAllUntyped());
        }
        else
        {
            Console.WriteLine("Invalid category choice.\n");
        }
    }

    private static void ShowAllMovies(List<IMovieStorage> storages)
    {
        var allMovies = storages.SelectMany(s => s.FindAllUntyped());
        DisplayMovies("All Movies", allMovies);
    }

    private static void DisplayMovies<T>(string header, IEnumerable<T> movies)
    {
        Console.WriteLine($"--- {header} ---");
        int count = 0;

        foreach (var movie in movies)
        {
            Console.WriteLine(movie);
            count++;
        }
        
        if(count == 0)
            Console.WriteLine("No movies found.");
        Console.WriteLine();
    }
}