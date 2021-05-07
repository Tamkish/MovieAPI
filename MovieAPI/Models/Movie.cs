using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
	public class Movie
	{
		[Key]
		public int id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		public DateTime ReleaseDate { get; set; }
		[JsonIgnore]
		public ICollection<Director> Directors { get; set; }
	}
}
