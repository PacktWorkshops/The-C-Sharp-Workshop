using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ToDoList.App.TagHelpers
{
    public class KanbanListTagHelper : TagHelper
    {
        public string Size { get; set; }
        public string Name { get; set; }
        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", $"col-{Size}");

            output.PreContent.SetHtmlContent(
            $"<div class=\"card bg-light\">"
                 + "<div class=\"card-body\">"
                 + $"<h6 class=\"card-title text-uppercase text-truncate py-2\">{Name}</h6>"
                 + "<div class \"border border-light\">");

            var childContent = await output.GetChildContentAsync();
            output.Content.SetHtmlContent(childContent.GetContent());

            output.PostContent.SetHtmlContent(
            "</div>"
                 + "</div>"
                 + "</div>");

            output.TagMode = TagMode.StartTagAndEndTag;
        }
    }
}