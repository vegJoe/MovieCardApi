using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieCardApi.Models.Entities;

namespace MovieCardApi.Data
{
    public class MovieCardContext : DbContext
    {
        public MovieCardContext (DbContextOptions<MovieCardContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movie => Set<Movie>();
        public DbSet<Genre> Genre => Set<Genre>();
        public DbSet<Actor> Actor => Set<Actor>();
        public DbSet<Director> Director => Set<Director>();
        public DbSet<ContactInformation> ContactInformation => Set<ContactInformation>();
        public DbSet<MovieGenre> MovieGenre => Set<MovieGenre>();
        public DbSet<MovieActor> MovieActor => Set<MovieActor>();
    }
}
