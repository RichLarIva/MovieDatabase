namespace MovieDatabase.Models;

public struct MovieRating
{
    public double Score { get; }

    public MovieRating(double score)
    {
        Score = score;
    }
}