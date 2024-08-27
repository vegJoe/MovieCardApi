﻿namespace MovieCardApi.Models.Entities
{
    public class Genre
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public IEnumerable<MovieGenre> MovieGenres { get; set; }
    }
}
