using System;
using System.ComponentModel.DataAnnotations;

namespace AnderoTest_461.Models
{
	public class Task
	{
		[Key]
		public int ID { get; set; }

		[Required]
		public string Title { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime Created { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime Modified { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime Expired { get; set; }
	}
}