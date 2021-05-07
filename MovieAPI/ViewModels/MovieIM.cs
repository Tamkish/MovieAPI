using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.ViewModels
{
	public class MovieIM
	{
		[Required]
		public string Name { get; set; }
		public string ReleaseYearString { get; set; } // "dd/mm/yyyy"
		public int[] DirectorIds { get; set; }
	}
}
