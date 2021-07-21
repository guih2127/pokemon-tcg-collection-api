using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public async Task<IActionResult> RegisterUserCardAsync(string cardId)
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

        [Authorize]
        [HttpGet]
        [Route("cards")]
        public async Task<IActionResult> ListUserCardsAsync()
        {
            try
            {
                var userId = this.User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                var userCards = await _context.UserCards.Where(x => x.UserId == userId).ToListAsync();
                var userCardsIds = userCards.Select(x => x.CardId);

                return Ok(userCardsIds);
            }
            catch
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpDelete]
        [Route("{cardId}")]
        public async Task<IActionResult> RemoveUserCardAsync(string cardId)
        {
            try
            {
                var userId = this.User.Claims.Where(x => x.Type == "Id").FirstOrDefault().Value;
                var card = await _context.UserCards.Where(x => x.CardId == cardId).FirstOrDefaultAsync();
                var result = _context.UserCards.Remove(card);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
