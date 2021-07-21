using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pokemonTcgCollectionApi.Domain.Entities
{
    [Table("UserCard")]
    public class UserCardEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string UserId { get; set; }
        public string CardId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
