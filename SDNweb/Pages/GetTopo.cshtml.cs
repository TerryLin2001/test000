using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using System.Net;

namespace SDNweb.Pages
{
    public class GetTopoModel : PageModel
    {
        private readonly ILogger<GetTopoModel> _logger;

        public GetTopoModel(ILogger<GetTopoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;
        }

        public void OnPostGetData()
        {
            ViewData["Devices"] = GetONOSInformation("devices");
            ViewData["Hosts"] = GetONOSInformation("hosts");
            ViewData["Links"] = GetONOSInformation("links");

            string dateTime = DateTime.Now.ToString("d", new CultureInfo("en-US"));
            ViewData["TimeStamp"] = dateTime;

            ViewData["Test"] = "OnPostGetTopo execute complete";
        }

        public String GetONOSInformation(String getItem)
        {
            HttpClientHandler httpClientHandler = new HttpClientHandler()
            {
                Credentials = new NetworkCredential("onos", "rocks"),
            };

            using (var client = new HttpClient(httpClientHandler))
            {
                var endpoint = new Uri("http://192.168.98.129:8181/onos/v1/"+getItem);
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                return json;
            }
        }


    }
}