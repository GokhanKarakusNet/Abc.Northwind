using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Abc.Northwind.MvcWebUI.TagHelpers
{
    [HtmlTargetElement("deneme")]
    public class PagingTagHelper : TagHelper
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
            stringBuilder.Append("<ul class='pagination'>");
            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class='{0}'>", i == CurrentPage ? "active" : "");
                stringBuilder.AppendFormat("<a href='/product/index?page={0}&category={1}'>{2}</a>", i, CurrentCategory,
                    i);
                stringBuilder.AppendFormat("</li>");
            }

            output.Content.SetHtmlContent(stringBuilder.ToString());
            base.Process(context, output);
        }

    }
}



//using Microsoft.AspNetCore.Razor.TagHelpers;
//using System.Text;
//namespace Abc.Northwind.MvcWebUI.TagHelpers
//{
//    [HtmlTargetElement("pageer", Attributes = "total-pages, current-page, link-url")]
//    public class PagingTagHelper : TagHelper
//    {
//        public int CurrentPage { get; set; }
//        public int TotalPages { get; set; }
//        /// <summary>
//        /// The url that the paging link should point to
//        /// </summary>
//        [HtmlAttributeName("link-url")]
//        public string Url { get; set; }
//        public override void Process(TagHelperContext context, TagHelperOutput output)
//        {
//            if (
//                int.TryParse(context.AllAttributes["total-pages"].Value.ToString(), out int totalPages) &&
//                int.TryParse(context.AllAttributes["current-page"].Value.ToString(), out int currentPage))
//            {
//                var url = context.AllAttributes["link-url"].Value;
//                output.TagName = "div";
//                output.PreContent.SetHtmlContent(@"<ul class=""pagination"">");
//                for (var i = 1; i <= totalPages; i++)
//                {
//                    output.Content.AppendHtml($@"<li class=""{(i == currentPage ? "active" : "")}""><a href=""{url}?page={i}""  title=""Click to go to page {i}"">{ i}</a></li>");
//                }
//                output.PostContent.SetHtmlContent("</ul>");
//                output.Attributes.Clear();
//            }
//        }
//    }
//}
