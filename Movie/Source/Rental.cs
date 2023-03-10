
namespace Movie
{
    /// <summary>
    /// The rental class represents a customer renting a movie.
    /// </summary>
    public class Rental
    {
        private Movie _movie;
        private int _daysRented;

        public Rental(Movie movie, int daysRented)
        {
            _movie = movie;
            _daysRented = daysRented;
        }
        public int GetDaysRented()
        {
            return _daysRented;
        }
        public Movie GetMovie()
        {
            return _movie;
        }
    }
}
