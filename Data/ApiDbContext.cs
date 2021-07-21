using Microsoft.EntityFrameworkCore;
using pokemonTcgCollectionApi.Domain.Entities;
using pokemonTcgCollectionApi.Models;

namespace pokemonTcgCollectionApi.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<UserCardEntity> UserCards { get; set; }

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

    }
}