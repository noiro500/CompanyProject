using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Refit;

namespace RefitInterfaces
{
    public interface IContentServiceAddress
    {
        [Post("/gateway/v1/Address/GetPartOfAddress")]
        Task<List<string>> GetPartOfAddress(string parameter);
    }
}
