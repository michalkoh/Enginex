using MediatR;
using System.Collections.Generic;

namespace Enginex.Application.Categories.Queries
{
    public class GetCategoryEditListQuery : IRequest<IReadOnlyList<CategoryEdit>>
    {
    }
}
