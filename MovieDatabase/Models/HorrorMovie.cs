namespace MovieDatabase.Models;

public class HorrorMovie : Movie
{
    public HorrorMovie(string title, int id, MovieRating movieRating) : base(title, id, movieRating)
    {
    }

    public override string Category()
    {
        return "Horror";
    }

    public override string ToString()
    {
        return $"{Title}\n\tRating:{MovieRating.Score:F1}\n\tID: {Id}";
    }
}