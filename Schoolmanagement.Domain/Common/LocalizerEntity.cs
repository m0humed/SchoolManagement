using System.ComponentModel.DataAnnotations;

namespace Schoolmanagement.Domain.Common
{
    public class LocalizerEntity
    {
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string firstNameAr { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string secondNameAr { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string thirdNameAr { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string firstNameEn { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string secondNameEn { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        [MinLength(2)]
        public string thirdNameEn { get; set; } = null!;

        public string AddressAr { get; set; } = null!;
        public string AddressEn { get; set; } = null!;

        public (string, string, string, string) GetLocalizer()
        {
            var currentCulture = Thread.CurrentThread.CurrentCulture;
            if (currentCulture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return (firstNameAr, secondNameAr, thirdNameAr, AddressAr);
            return (firstNameEn, secondNameEn, thirdNameEn, AddressEn);
        }



    }
}
