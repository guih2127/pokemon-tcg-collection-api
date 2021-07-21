using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace pokemonTcgCollectionApi.Domain.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public List<UserCardEntity> Cards { get; set; }
    }
}