using AutoMapper;
using Enginex.Application.Common.Mappings;
using Enginex.Domain.Entities;

namespace Enginex.Application.Categories.Queries.GetCategories
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryViewModel>()
                .ConvertUsing(c =>
                System.Threading.Thread.CurrentThread.CurrentCulture == new System.Globalization.CultureInfo("en") ? 
                    new CategoryViewModel() { Name = c.NameEn } :
                    new CategoryViewModel() { Name = c.NameSk });
        }
    }
}
