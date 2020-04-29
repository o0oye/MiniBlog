using System;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace MiniBlog.Core.Plugin
{
    public class PagerTagHelper : TagHelper
    {
        public string ActionUrl { get; set; }
        public PagerOption Option { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Option.PageSize < 1) { Option.PageSize = 1; }
            if (Option.PageIndex < 1) { Option.PageIndex = 1; }
            if (Option.Total < 1) { return; }

            var totalPage = (int)Math.Ceiling(Option.Total / (double)Option.PageSize);
            var pageBuider = new StringBuilder();
            output.TagName = "";
            switch (Option.Style)
            {
                default:
                    pageBuider.Append("<nav aria-label=\"...\">");
                    pageBuider.Append("<ul class=\"pagination\">");
                    for (int i = 1; i < totalPage + 1; i++)
                    {
                        pageBuider.Append($"<li class=\"page-item\"><a href=\"{ActionUrl}?index={i}\" class=\"page-link\">{i}</a></li>");
                    }
                    pageBuider.Append($"<li> Rows:{Option.Total} Total:{totalPage}</li>");
                    pageBuider.Append("</ul>");
                    pageBuider.Append("</nav>");
                    break;
            }
            output.Content.SetHtmlContent(pageBuider.ToString());
        }
    }

    public class PagerOption
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int Style { get; set; }
    }
}
