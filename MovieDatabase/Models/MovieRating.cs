namespace MovieDatabase.Models;

public struct MovieRating
{
    public double Score { get; init; }

    public MovieRating(double score)
    {
        Score = score;
    }
}