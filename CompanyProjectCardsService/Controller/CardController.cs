using CompanyProjectCardsService.Model;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectCardsService.Controller
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));

        [HttpGet("{pageNameForCard:regex(^\\w+$)}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(MainCard))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetCardsAsync(string pageNameForCard)
        {
            var repository = _unitOfWork.Repository<MainCard>();
            var query = repository.MultipleResultQuery().AndFilter(card => card.PageNameForCard == pageNameForCard)
                .Include(s => s.Include(c => c.CardFooterItems));
            var result =await repository.SearchAsync(query);
            return Ok(result);
        }
    }
}
