using System.Globalization;

namespace SchoolSystem_Data.Commons
{
	public class LocalizableEntity
	{
		public string NameAr { get; set; }

		public string NameEn { get; set; }

		public string GetLocalized()
		{
			// to Get Current Culture
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;

			if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
			{
				return NameAr;
			}
			else
			{
				return NameEn;
			}
		}
	}
}
