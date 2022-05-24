using System.ComponentModel.DataAnnotations;

namespace Starter.Console.DTO.Intent
{
    public class IntentModificationModel
    {
        [Required]
        public string Name { get; set; }
    }
}
