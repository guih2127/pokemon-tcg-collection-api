using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using pokemonTcgCollectionApi.Data;
using pokemonTcgCollectionApi.Domain.Entities;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace pokemonTcgCollectionApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCardController : ControllerBase
    {
        private readonly ApiDbContext _context;
        public UserCardController(ApiDbContext context)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost]
        [Route("{cardId}")]
        public async Task<IActionResult> RegisterUserCardAsync(int cardId)
        {
            try
            {
                var userId = this.User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                var userCard = new UserCardEntity { CardId = cardId, UserId = userId };

                var result = await _context.UserCards.AddAsync(userCard);
                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }
    }
}
