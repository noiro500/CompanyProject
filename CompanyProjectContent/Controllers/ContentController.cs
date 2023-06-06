using CompanyProjectContentService.CQRS.Queries;
using CompanyProjectContentService.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContentService.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMediator _mediator;

    public ContentController(IUnitOfWork unitOfWork, IMediator mediator)
    {
        _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet("{pageName:regex(^\\w+$)}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPageContentAsync(string pageName)
    {
        var result = await _mediator.Send(new GetPageContentQuery(pageName, _unitOfWork));
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTopMenuEntitiesAsync()
    {
        var result = await _mediator.Send(new GetTopMenuEntitiesQuery( _unitOfWork));
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFooterContentAsync()
    {
        //var repository = _unitOfWork.Repository<Page>();
        //var query = repository.MultipleResultQuery();
        //var result = await repository.SearchAsync(query);
        var result = await _mediator.Send(new GetFooterContentQuery(_unitOfWork));
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{isUsing:bool}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompanyContactAsync(bool isUsing)
    {
        var result = await _mediator.Send(new GetCompanyContactQuery(isUsing, _unitOfWork));
        if (result is null)
            return NotFound();
        return Ok(result);
    }
}