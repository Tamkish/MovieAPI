using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Models
{
	public class Creation
	{
		public int DirectorId { get; set; }
		public int MovieId { get; set; }
		public Director Director { get; set; }
		public Movie Movie { get; set; }
	}
}
