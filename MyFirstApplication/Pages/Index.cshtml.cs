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
        [Required(ErrorMessage = "First name is required.")]
        [MaxLength(14, ErrorMessage = "First name is too long. It must be at most 14 characters.")]
        [MinLength(2, ErrorMessage = "First name is too short. It must be at least 2 characters.")]
        public string firstNameInput { get; set; }
        
        [BindProperty]
        [Required(ErrorMessage = "Email address is required.")]
        [MaxLength(254, ErrorMessage = "Email address is too long. It must be at most 254 characters.")]
        [MinLength(5, ErrorMessage = "Email address is too short. It must be at least 5 characters.")]
        [RegularExpression("[a-zA-Z0-9.!#$%&’*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*", //credit: https://emailregex.com/index.html
            ErrorMessage = "Email address does not fit standards. This may be due to invalid special characters (only !#$%&'*+/=?^_`|~- are allowed, and only in the name portion). It may also be due to invalid structure, proper structure would be name@domain.")]
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

            this.firstName = Request.Form["firstNameInput"];
            this.emailAddress = Request.Form["emailAddressInput"];

            return Page();
        }
    }
}
