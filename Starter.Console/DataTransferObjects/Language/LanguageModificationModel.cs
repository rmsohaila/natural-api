using System.ComponentModel.DataAnnotations;

namespace Starter.Console.DTO.Language
{
    public class LanguageModificationModel
    {
        [Required]
        public string Name { get; set; }

        [MaxLength(5, ErrorMessage = "Maximum length should be 5 characters e.g. EN-US")]
        public string ISOCODE { get; set; }
    }
}
