
namespace Schoolmanagement.Domain.Common
{
    public class GlobalLocalizer
    {

        public string GetLocalized(string textAr, string textEn)
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            if (currentCulture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return textAr;
            return textEn;
        }

    }
}
