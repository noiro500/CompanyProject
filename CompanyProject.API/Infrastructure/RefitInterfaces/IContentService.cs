﻿using System.Threading.Tasks;
using CompanyProject.API.Infrastructure.Dto;
using CompanyProject.API.Infrastructure.HelpClasses;
using Refit;

namespace CompanyProject.API.Infrastructure.RefitInterfaces;

public interface IContentService
{
    [Get("/api/v1/Content/{pageName}")]
    Task<PageDto> GetPageContentAsync(string pageName);
}