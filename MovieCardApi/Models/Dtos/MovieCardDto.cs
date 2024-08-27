namespace MovieCardApi.Models.Dtos
{

    public record MovieCardDto(int Id, string Title, int Rating, int ReleaseDate, string Description, string DirectorName, string Email, int Phonenumber, string Genre);

    public record MovieActorsDto(string Name, int DateOfBirth);
    public class MovieCardDetailsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Rating { get; set; }
        public int ReleaseDate { get; set; }
        public string Description { get; set; }
        public string DirectorName { get; set; }
            public string Email { get; set; }
            public int Phonenumber { get; set; }
        public string Genre { get; set; }

        public IEnumerable<MovieActorsDto> Actors { get; set; }
    }
}
