using System;
using System.Text;
using Microsoft.AspNetCore.Razor.TagHelpers;


namespace MiniBlog.Core.Plugin
{
    public class PagerTagHelper : TagHelper
    {
        public string ActionUrl { get; set; }
        public PagerOption Option { get; set; }

        public bool ShowMore { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Option.PageSize < 1) { Option.PageSize = 1; }
            if (Option.PageIndex < 1) { Option.PageIndex = 1; }
            if (Option.Total < 1) { return; }

            var totalPage = (int)Math.Ceiling(Option.Total / (double)Option.PageSize);

            //开始页码
            var showStart = Option.PageIndex - 2 > 0 ? Option.PageIndex - 2 : 1;
            //结束页码
            var showEnd = Option.PageIndex + 2 >= totalPage ? totalPage : Option.PageIndex + 2;

            var pageBuider = new StringBuilder();
            output.TagName = "";
            switch (Option.Style)
            {
                default:
                    pageBuider.Append("<nav aria-label=\"...\">");
                    pageBuider.Append("<ul class=\"pagination pagination-lg\">");
                    for (int i = showStart; i < showEnd + 1; i++)
                    {
                        var page_item = Option.PageIndex == i ? "page-item active" : "page-item";
                        pageBuider.Append($"<li class=\"{page_item}\"><a href=\"{ActionUrl}?index={i}\" class=\"page-link\">{i}</a></li>");
                    }
                    if (ShowMore)
                    {
                        pageBuider.Append($"<li> Rows:{Option.Total} Total:{totalPage}</li>");
                    }
                    pageBuider.Append("</ul>");
                    pageBuider.Append("</nav>");
                    break;
            }
            output.Content.SetHtmlContent(pageBuider.ToString());
        }
    }

    //分页设置

    public class PagerOption
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int Total { get; set; }
        public int Style { get; set; }
    }
}
