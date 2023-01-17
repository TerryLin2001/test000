using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;

namespace SDNweb.Pages
{
    public class PostTestModel : PageModel
    {
        private readonly ILogger<PostTestModel> _logger;

        public PostTestModel(ILogger<PostTestModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;
        }

        public void OnPostPostTest()
        {

            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;

            ViewData["Test"] = "OnPostPostTest execute complete";
        }
    }
}
