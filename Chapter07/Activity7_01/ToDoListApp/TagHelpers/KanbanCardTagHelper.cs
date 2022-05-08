namespace ToDoListApp.TagHelpers;

using Microsoft.AspNetCore.Razor.TagHelpers;

public class KanbanCardTagHelper : TagHelper
{
    public string? Task { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", "card");

        output.PreContent.SetHtmlContent(
        "<div class=\"card-body p-2\">"
             + "<div class=\"card-title\">");

        output.Content.SetContent(Task);

        output.PostContent.SetHtmlContent(
        "</div>"
             + "<button class=\"btn btn-primary btn-sm\">View</button>"
             + "</div>");

        output.TagMode = TagMode.StartTagAndEndTag;
    }

}
