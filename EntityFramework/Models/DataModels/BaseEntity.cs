using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Models.DataModels
{
    public class BaseEntity
    {
        [Required]
        [Key]
        public int Id { get; set; }

    }
}
