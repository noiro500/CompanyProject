using System.Text.Json;
using CompanyProjectContentService.Infrastructure.Dto;
using CompanyProjectContentService.Models.Page;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContentService.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ContentController(IUnitOfWork unitOfWork) =>_unitOfWork=unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
    // GET
    [HttpGet("{pageName:alpha}")]
    [ProducesResponseType(200, Type = typeof(Page))]
    [ProducesResponseType(400)]
    public async Task<ActionResult> GetPageContentAsync(string pageName)
    {
        var repository =_unitOfWork.Repository<Page>();
        var query = repository.SingleResultQuery().AndFilter(page => page.Name == pageName)
            .Include(source => source.Include(p => p.Paragraphs));
        var result =await repository.FirstOrDefaultAsync(query);
        if (result is null)
            return NoContent();
        var pageResult = new PageDto(result.PageId, result.Name, result.ScreenName, result.Icon, result.ToNavbar, result.Paragraphs);
        return Ok(JsonSerializer.Serialize<PageDto>(pageResult));
    }
}