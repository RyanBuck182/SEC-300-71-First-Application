using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyFirstApplication.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public string firstName {  get; set; }
        public string emailAddress { get; set; }

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet(string firstName, string emailAddress) {
            this.firstName = firstName;
            this.emailAddress = emailAddress;
        }
        
        public IActionResult OnPost() {
            this.firstName = Request.Form["firstName"];
            this.emailAddress = Request.Form["emailAddress"];

            return Page();
        }
    }
}
