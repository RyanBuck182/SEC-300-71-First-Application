using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace MyFirstApplication.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public string firstName {  get; set; }
        public string emailAddress { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email address is required.")]
        [MaxLength(254, ErrorMessage = "Email address is too long. It must be at most 254 characters.")]
        [MinLength(5, ErrorMessage = "Email address is too short. It must be at least 5 characters.")]
        [RegularExpression("(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])", //credit: https://emailregex.com/index.html
            ErrorMessage = "Email address does not fit standards. This may be due to invalid special characters (only !#$%&'*+/=?^_`|~- are allowed). It may also be due to invalid structure, proper structure would be name@domain.")]
        public string emailAddressInput { get; set; }

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public void OnGet(string firstName, string emailAddress) {
            this.firstName = firstName;
            this.emailAddress = emailAddress;
        }
        
        public IActionResult OnPost() {
            // If input is invalid, return
            if (!ModelState.IsValid) {
                return Page();
            }

            this.firstName = Request.Form["firstName"];
            this.emailAddress = Request.Form["emailAddressInput"];

            return Page();
        }
    }
}
