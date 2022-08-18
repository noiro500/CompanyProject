using CompanyProjectCardsService.Model;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectCardsService.Controller
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public CardController(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork ?? throw new AggregateException(nameof(unitOfWork));

        [HttpGet("{pageNameForCard:alpha}")]
        [ProducesResponseType(200, Type = typeof(MainCard))]
        [ProducesResponseType(400)]
        public IActionResult GetCards(string pageNameForCard)
        {
            var repository = _unitOfWork.Repository<MainCard>();
            var query = repository.MultipleResultQuery().AndFilter(card => card.PageNameForCard == pageNameForCard)
                .Include(s => s.Include(c => c.CardFooterItems));
            var result = repository.Search(query).ToList();
            return Ok(result);
        }
    }
}
