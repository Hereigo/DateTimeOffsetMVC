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

		public string SavedDates { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime Created { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime Modified { get; set; }

		[Required]
		// [CustomDateTimeValidator] - Not valid: Incoming from FrontEnd as '01-Jan-18 23:59:59'
		[DataType(DataType.DateTime)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm}", ApplyFormatInEditMode = true)]
		public DateTime Expired { get; set; }
	}
}