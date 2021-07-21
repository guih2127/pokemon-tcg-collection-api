using Microsoft.AspNetCore.Identity;

namespace pokemonTcgCollectionApi.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public UserCardEntity Cards { get; set; }
    }
}