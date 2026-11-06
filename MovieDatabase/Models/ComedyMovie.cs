namespace MovieDatabase.Models;

public class ComedyMovie : Movie
{
    public ComedyMovie(string title, int id, MovieRating movieRating) : base(title, id, movieRating)
    {
    }

    public override string Category()
    {
        return "Comedy";
    }

    public override string ToString()
    {
        return $"{Title}\n\tRating:{MovieRating.Score:F1}\n\tID: {Id}";
    }
}
