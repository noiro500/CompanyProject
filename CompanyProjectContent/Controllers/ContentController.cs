using System.Text.Json;
using CompanyProjectContent.Infrastructure.DTO;
using CompanyProjectContent.Models.Page;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContent.Controllers;

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
        var pageResult = new PageDto
        {
            PageId = result.PageId,
            Name = result.Name,
            ScreenName = result.ScreenName,
            Icon = result.Icon,
            ToNavbar = result.ToNavbar,
            ToCard = result.ToCard,
            };
        var listParagraphs = new List<ParagraphDto>();
        foreach (var resultParagraph in result.Paragraphs)
        {
            listParagraphs.Add(new ParagraphDto
            {
                Content = resultParagraph.Content,
                HasPicture = resultParagraph.HasPicture,
                IsGlobalTitle = resultParagraph.IsGlobalTitle,
                IsList = resultParagraph.IsList,
                IsMobileVisible = resultParagraph.IsMobileVisible,
                IsSubtitle = resultParagraph.IsSubtitle,
                ParagraphId = resultParagraph.ParagraphId,
                PicturePath = resultParagraph.PicturePath
            });
        }
        pageResult.Paragraphs= listParagraphs.ToList();
        return Ok( pageResult);
    }
}