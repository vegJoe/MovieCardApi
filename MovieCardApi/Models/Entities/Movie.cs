namespace MovieCardApi.Models.Entities
{
    public class Movie
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public int Rating { get; set; }

        public int Releasedate { get; set; }

        public string Description { get; set; }

        public int DirectorId { get; set; }
        public Director Director { get; set; }

        public IEnumerable<MovieActor> Actors { get; set; }

        public IEnumerable<MovieGenre> Genres { get; set; }
    }
}
