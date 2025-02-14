using Microsoft.AspNetCore.Mvc.Rendering;

namespace ScoreTracker
{
    public static class HtmlHelpers
    {
        public static IEnumerable<SelectListItem> GetSelections(this IHtmlHelper htmlHelper, string selectedViewData)
        {
            return htmlHelper.ViewData[selectedViewData] as IEnumerable<SelectListItem>;
        }
    }
}
