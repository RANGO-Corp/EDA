using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Alere.TagHelpers
{
    public class AlertTagHelper : TagHelper
    {
        public string Message { get; set; }
        public Severity Severity { get; set; } = Severity.info;
        public bool Dismissible { get; set; } = false;
        public string Class { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("role", "alert");
            output.Attributes.SetAttribute("class", $"alert alert-{Severity} fade show {Class} {(Dismissible ? "alert-dismissible" : "")}");
            output.Content.SetContent(Message);
            if (Dismissible)
            {
                output.Content.AppendHtml("<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button>");
            }
        }
    }

    public enum Severity
    {
        info,
        danger,
        warning,
        success,
        primary,
        secondary
    }
}