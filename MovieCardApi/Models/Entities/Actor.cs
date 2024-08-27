namespace MovieCardApi.Models.Entities
{
    public class Actor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int DateOfBirth { get; set; }

        public IEnumerable<MovieActor> StaredIn { get; set; }
    }
}
