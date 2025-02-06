using MediatR;
using CleanLibrary.Application.Common;
using CleanLibrary.Domain.Models;
using System.Collections.Generic;

namespace CleanLibrary.Application.Authors.Queries.GetAllAuthors
{
    public class GetAllAuthorsQuery : IRequest<OperationResult<List<Author>>>
    {
    }
}
