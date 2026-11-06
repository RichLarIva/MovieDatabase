namespace MovieDatabase.Models;

public abstract class Movie
{
    protected Movie(string title, int id, MovieRating movieRating)
    {
        Id = id;
        Title = title;
        MovieRating = movieRating;
    }

    public int Id { get; private set; }
    public string Title { get; private set; }
    public MovieRating MovieRating { get; private set; }

    public abstract string Category();
}