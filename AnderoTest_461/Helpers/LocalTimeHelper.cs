using System;
using System.Web;
using System.Web.Mvc;

namespace AnderoTest_461.Helpers
{
	public static class LocalTimeHelper
	{
		public static HtmlString Format(this HtmlHelper htmlHelper, DateTime date)
		{
			TimeSpan delta = TimeZoneInfo.Local.GetUtcOffset(date);

			double offset = delta.TotalMinutes;

			return new HtmlString(date.AddMinutes(offset).ToString("yyyy-MM-dd HH:mm"));
		}
	}
}