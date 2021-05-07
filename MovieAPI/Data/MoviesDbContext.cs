using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieAPI.Models;

namespace MovieAPI.Data
{
	public class MoviesDbContext : DbContext
	{
		public MoviesDbContext(DbContextOptions<MoviesDbContext> options) : base(options) { }

		public DbSet<Director> Directors { get; set; }
		public DbSet<Movie> Movies { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Director>()
				.HasMany(d => d.Movies)
				.WithMany(m => m.Directors)
				.UsingEntity<Creation>(x => x.HasOne(c => c.Movie).WithMany().HasForeignKey(x => x.MovieId), x => x.HasOne(c => c.Director).WithMany().HasForeignKey(x => x.DirectorId));


			modelBuilder.Entity<Director>().HasData(new Director { Id = 1, FirstName = "Christopher",	LastName = "Nolan"});
			modelBuilder.Entity<Director>().HasData(new Director { Id = 2, FirstName = "Lana",			LastName = "Wachowski" });
			modelBuilder.Entity<Director>().HasData(new Director { Id = 3, FirstName = "Lilly",			LastName = "Wachowski"});
			modelBuilder.Entity<Director>().HasData(new Director { Id = 4, FirstName = "Quentin",		LastName = "Tarantino"});
			modelBuilder.Entity<Director>().HasData(new Director { Id = 5, FirstName = "Tim",			LastName = "Burton"});
			modelBuilder.Entity<Director>().HasData(new Director { Id = 6, FirstName = "Edgar",			LastName = "Wright"});
			modelBuilder.Entity<Director>().HasData(new Director { Id = 7, FirstName = "Anthony",		LastName = "Russo"});
			modelBuilder.Entity<Director>().HasData(new Director { Id = 8, FirstName = "Joseph",		LastName = "Russo"});
			
			
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 1,  Name = "The Nightmare Before Christmas",		ReleaseDate = new DateTime(1993,10,29)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 2,  Name = "Pulp Fiction",						ReleaseDate = new DateTime(1994,5,21)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 3,  Name = "Matrix",								ReleaseDate = new DateTime(1999,3,31)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 4,  Name = "Memento",								ReleaseDate = new DateTime(2000,9,5)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 5,  Name = "Kill Bill",							ReleaseDate = new DateTime(2003,10,10)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 6,  Name = "Charlie and the Chocolate Factory",	ReleaseDate = new DateTime(2005,7,10)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 7,  Name = "Corpse Bride",						ReleaseDate = new DateTime(2005,9,7)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 8,  Name = "Hot Fuzz",							ReleaseDate = new DateTime(2007,2,16)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 9,  Name = "The Dark Knight",						ReleaseDate = new DateTime(2008,7,14)});
		 	modelBuilder.Entity<Movie>().HasData(new Movie { id = 10, Name = "Alice in Wonderland",					ReleaseDate = new DateTime(2010,2,25)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 11, Name = "Inception",							ReleaseDate = new DateTime(2010,7,8)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 12, Name = "Scott Pilgrim vs. the World",			ReleaseDate = new DateTime(2010,8,27)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 13, Name = "Django Unchained",					ReleaseDate = new DateTime(2012,12,11)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 14, Name = "Interstellar",						ReleaseDate = new DateTime(2014,10,26)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 15, Name = "Ant-Man",								ReleaseDate = new DateTime(2015,6,29)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 16, Name = "The Hateful Eight",					ReleaseDate = new DateTime(2015,12,7)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 17, Name = "Captain America: Civil War",			ReleaseDate = new DateTime(2016,4,12)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 18, Name = "Baby Driver",							ReleaseDate = new DateTime(2017,3,11)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 19, Name = "Avengers: Infinity War",				ReleaseDate = new DateTime(2018,5,23)});
			modelBuilder.Entity<Movie>().HasData(new Movie { id = 20, Name = "Avengers: Endgame",					ReleaseDate = new DateTime(2019,4,22)});

			//christopher nolan
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 1, MovieId = 4},
				new Creation { DirectorId = 1, MovieId = 9},
				new Creation { DirectorId = 1, MovieId = 11},
				new Creation { DirectorId = 1, MovieId = 14}
			);

			//wachowski sisters
			//Lana
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 2, MovieId = 3 }
			);
			//Lilly
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 3, MovieId = 3 }
			);

			//quentin tarantino
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 4, MovieId = 2 },
				new Creation { DirectorId = 4, MovieId = 5 },
				new Creation { DirectorId = 4, MovieId = 13 },
				new Creation { DirectorId = 4, MovieId = 16 }
			);

			//tim burton
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 5, MovieId = 1 },
				new Creation { DirectorId = 5, MovieId = 6 },
				new Creation { DirectorId = 5, MovieId = 7 },
				new Creation { DirectorId = 5, MovieId = 10 }
			);

			//edgar wright
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 6, MovieId = 8 },
				new Creation { DirectorId = 6, MovieId = 12 },
				new Creation { DirectorId = 6, MovieId = 15 },
				new Creation { DirectorId = 6, MovieId = 18 }
			);

			//russo brothers
			//anthony
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 7, MovieId = 17 },
				new Creation { DirectorId = 7, MovieId = 19 },
				new Creation { DirectorId = 7, MovieId = 20 }
			);
			//anthony
			modelBuilder.Entity<Creation>().HasData(
				new Creation { DirectorId = 8, MovieId = 17 },
				new Creation { DirectorId = 8, MovieId = 19 },
				new Creation { DirectorId = 8, MovieId = 20 }
			);




		}
	}
}
