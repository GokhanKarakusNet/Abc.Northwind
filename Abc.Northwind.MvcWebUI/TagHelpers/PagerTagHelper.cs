using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Abc.Northwind.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("paging")]
    public class PagerTagHelper : TagHelper
    {
        [HtmlAttributeName("page-size")]
        public int PageSize { get; set; }
        [HtmlAttributeName("page-count")]
        public int PageCount { get; set; }
        [HtmlAttributeName("current-category")]
        public int CurrentCategory { get; set; }
        [HtmlAttributeName("current-page")]
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"<ul class=""pagination"">");

            stringBuilder.AppendFormat("<li class='{0}'>", CurrentPage == 1 ? "page-item disabled" : "page-item");
            stringBuilder.AppendFormat(@"<a class=""page-link"" href='/product/index?page={0}&category={1}'>{2}</a>", CurrentPage - 1, CurrentCategory,
                "Previous");
            stringBuilder.AppendFormat("</li>");
            for (int i = 1; i <=PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class='{0}'>", i == CurrentPage ? "page-item active" : "page-item");
                stringBuilder.AppendFormat(@"<a class=""page-link"" href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory,
                    i);
            }
            stringBuilder.AppendFormat("</li>");
            stringBuilder.AppendFormat("<li class='{0}'>", CurrentPage == PageCount ? "page-item disabled" : "page-item");
            stringBuilder.AppendFormat(@"<a class=""page-link"" href='/product/index?page={0}&category={1}'>{2}</a>", CurrentPage + 1, CurrentCategory,
                "Next");
            stringBuilder.AppendFormat("</li>");


            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }

    }
}

