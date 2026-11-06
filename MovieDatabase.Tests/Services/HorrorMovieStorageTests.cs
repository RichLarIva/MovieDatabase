using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MovieDatabase.Models;
using MovieDatabase.Services;

namespace MovieDatabase.Tests.Services;

[TestClass]
public class HorrorMovieStorageTests
{
    private string filePath;
    private HorrorMovieStorage storage;
    private DirectoryInfo tempDir;

    [TestInitialize]
    public void SetUp()
    {
        // Creates a UNIQUE temporary directory for each test run
        tempDir = Directory.CreateTempSubdirectory();
        filePath = Path.Combine(tempDir.FullName, "horror.json");
        storage = new HorrorMovieStorage(filePath);
    }

    [TestCleanup]
    public void CleanUp()
    {
        // Clean up the temp directory after the test finishes
        if (tempDir.Exists)
            try
            {
                tempDir.Delete(true);
            }
            catch
            {
                // ignored
            }
    }

    [TestMethod]
    [Description("Should save and find a horror movie")]
    public void TestShouldSaveAndFindMovie()
    {
        var movie = new HorrorMovie("VERY SCARY MOVIE!1!", 1, new MovieRating(10));
        storage.Save(movie);

        var result = storage.FindById(1);
        
        Assert.IsNotNull(result);
        Assert.AreEqual(1, result.Id);
        Assert.AreEqual("VERY SCARY MOVIE!1!", result.Title);
        Assert.AreEqual(10, result.MovieRating.Score);
    }
    
    [TestMethod]
    [Description("Should return empty list")]
    public void TestShouldReturnEmptyList()
    {
        Assert.IsTrue(storage.FindAll().Count == 0);
    }
    
    [TestMethod]
    [Description("Should not save movies with duplicate IDs")]
    public void TestShouldNotSaveMoviesWithDuplicateIDs()
    {
        var firstMovie = new HorrorMovie("VERY SCARY MOVIE!1!", 1, new MovieRating(4.0));
        var secondMovie = new HorrorMovie("potatoes in space", 1, new MovieRating(2.5));

        storage.Save(firstMovie);
        storage.Save(secondMovie);

        var movies = storage.FindAll();

        Assert.AreEqual(1, movies.Count);
        Assert.AreEqual("VERY SCARY MOVIE!1!", movies.First().Title);
        Assert.AreEqual(1, movies.First().Id);
        Assert.AreEqual(4.0, movies.First().MovieRating.Score);
    }

    [TestMethod]
    [Description("Should return null when movie ID does not exist")]
    public void TestShouldReturnNullWhenMovieIdDoesNotExist()
    {
        var movie = new HorrorMovie("Potatoes vs Mashed Potatoes", 1, new MovieRating(3.0));

        storage.Save(movie);

        var result = storage.FindById(2);

        Assert.IsNull(result);
    }
}