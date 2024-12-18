using System.Globalization;

namespace SchoolSystem_Data.Commons
{
	public class GeneralLocalizableEntity
	{
		public string GetLocalized(string textAr, string textEn)
		{
			CultureInfo culture = Thread.CurrentThread.CurrentCulture;

			if (culture.TwoLetterISOLanguageName.ToLower().Equals("en"))
			{
				return textEn;
			}
			else
			{
				return textAr;
			}
		}
	}
}
