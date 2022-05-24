using System.ComponentModel.DataAnnotations;

namespace Starter.Console.DTO.Intent
{
    public class IntentCreationModel
    {
        [Required]
        public string Name { get; set; }
    }
}
