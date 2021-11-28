using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zoo.Core.Models
{
    [Table("__EFMigrationsHistory")]
    public class MigrationsHistory : IModel
    {
        [Key]
        public string MigrationId { get; set; }

        public string ProductVersion { get; set; }

        public bool IsSeeded { get; set; }
    }
}