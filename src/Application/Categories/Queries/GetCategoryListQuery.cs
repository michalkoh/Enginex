using System.Collections.Generic;
using MediatR;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryListQuery : IRequest<IReadOnlyList<CategoryDto>>
    {
    }
}
