﻿using CompanyProjectContentService.Models;
using EntityFrameworkCore.UnitOfWork.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CompanyProjectContentService.Controllers;

[Route("api/v1/[controller]/[action]")]
[ApiController]
public class ContentController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ContentController(IUnitOfWork unitOfWork) =>_unitOfWork=unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));

    [HttpGet("{pageName:regex(^\\w+$)}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Page))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetPageContentAsync(string pageName)
    {
        var repository =_unitOfWork.Repository<Page>();
        var query = repository.SingleResultQuery().AndFilter(page => page.Name == pageName)
            .Include(source => source.Include(p => p.Paragraphs));
        var result =await repository.FirstOrDefaultAsync(query);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TopMenuEntity))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTopMenuEntitiesAsync()
    {
        var repository = _unitOfWork.Repository<TopMenuEntity>();
        var query = repository.MultipleResultQuery();
        var result = await repository.SearchAsync(query);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IList<Page>))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetFooterContentAsync()
    {
        var repository = _unitOfWork.Repository<Page>();
        var query = repository.MultipleResultQuery();
        var result = await repository.SearchAsync(query);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpGet("{isUsing:bool}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CompanyContact))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetCompanyContactAsync(bool isUsing)
    {
        var repository = _unitOfWork.Repository<CompanyContact>();
        var query = repository.SingleResultQuery().AndFilter(company => company.CompanyIsUsing ==isUsing);
        var result = await repository.FirstOrDefaultAsync(query);
        if (result is null)
            return NotFound();
        return Ok(result);
    }
}