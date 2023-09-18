using System.ComponentModel.DataAnnotations;

namespace AzureKeyVaultDemo.Models
{
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Color { get; set; }
        public DateTime Birthday { get; set; }
        public string Notes { get; set; }

    }
}
