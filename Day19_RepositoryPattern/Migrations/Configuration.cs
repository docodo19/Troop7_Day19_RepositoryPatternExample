namespace Day19_RepositoryPattern.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            Movie[] movies = new Movie[]
            {
                new Movie { Title = "Die Hard", Director = "Bob" },
                new Movie { Title = "Kill Bill", Director = "John" },
                new Movie { Title = "Bourne Identity", Director = "Timmy" }
            };

            context.Movies.AddOrUpdate(m => m.Title, movies);

        }
    }
}
