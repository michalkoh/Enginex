﻿using Enginex.Web.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Enginex.Web.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;

        public PageLinkTagHelper(IUrlHelperFactory helperFactory)
        {
            this.urlHelperFactory = helperFactory;
            ViewContext = new ViewContext();
            PageModel = new PagingInfo();
            PageAction = string.Empty;
            PageClass = string.Empty;
            PageClassNormal = string.Empty;
            PageClassSelected = string.Empty;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        public bool PageClassEnabled { get; set; } = false;

        public string PageClass { get; set; }

        public string PageClassNormal { get; set; }

        public string PageClassSelected { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var urlHelper = this.urlHelperFactory.GetUrlHelper(ViewContext);
            var result = new TagBuilder("div");
            if (PageModel.TotalPages > 1)
            {
                for (var i = 1; i <= PageModel.TotalPages; i++)
                {
                    var tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(new UrlActionContext() { Action = PageAction, Values = new { page = i } });
                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    tag.InnerHtml.AppendHtml(i.ToString() + " ");
                    result.InnerHtml.AppendHtml(tag);
                }
            }

            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
